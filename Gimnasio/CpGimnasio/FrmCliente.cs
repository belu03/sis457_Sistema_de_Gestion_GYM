using CadGimnasio;
using ClnGimnasio;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FrmCliente : Form
    {
        private bool esNuevo = false;

        public FrmCliente()
        {
            InitializeComponent();
        }

        private void listar()
        {
            if (cbxInactivos.Checked)
            {
                var listaInactivos = ClienteCln.listarInactivos(txtParametro.Text)
                                               .Where(c => c.estado == -1).ToList();
                dgvLista.DataSource = listaInactivos;
                btnEliminar.Text = "Reactivar";
            }
            else
            {
                var listaActivos = ClienteCln.listarPa(txtParametro.Text)
                                             .Where(c => c.estado == 1).ToList();
                dgvLista.DataSource = listaActivos;
                btnEliminar.Text = "Eliminar";
            }

            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["ci"].HeaderText = "Carnet (CI)";
            dgvLista.Columns["nombre"].HeaderText = "Nombres";
            dgvLista.Columns["apellido"].HeaderText = "Apellidos";
            dgvLista.Columns["telefono"].HeaderText = "Teléfono";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            if (dgvLista.RowCount > 0)
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1264, 440);

            gbxLista.Height = 250;
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            pnlAcciones.Location = new Point(20, 370);
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxDatos.Visible = false;

            listar();
            EstilosUI.FormatearGrilla(dgvLista);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            pnlAcciones.Enabled = false;


            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;


            this.ClientSize = new Size(1264, 680);


            gbxDatos.Location = new Point(20, 440);
            gbxDatos.Size = new Size(1224, 210);
            gbxDatos.Visible = true;
            gbxDatos.BringToFront();

            limpiar();
            txtCI.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null) return;
            esNuevo = false;
            pnlAcciones.Enabled = false;


            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            this.ClientSize = new Size(1264, 680);


            gbxDatos.Location = new Point(20, 440);
            gbxDatos.Size = new Size(1224, 210);
            gbxDatos.Visible = true;
            gbxDatos.BringToFront();

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var cliente = ClienteCln.obtenerUno(id);
            txtCI.Text = cliente.ci;
            txtNombre.Text = cliente.nombre;
            txtApellido.Text = cliente.apellido;
            txtTelefono.Text = cliente.telefono;
            txtCorreo.Text = cliente.correo;
            txtCI.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            gbxDatos.Visible = false;


            this.ClientSize = new Size(1264, 440);


            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            pnlAcciones.Enabled = true;
            listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e) => listar();

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        private void limpiar()
        {
            txtCI.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            resetearErrores();
        }

        private void resetearErrores()
        {
            erpCI.Clear();
            erpNombre.Clear();
            erpApellido.Clear();
        }

        private bool validar()
        {
            bool esValido = true;
            resetearErrores();
            if (string.IsNullOrWhiteSpace(txtCI.Text)) { erpCI.SetError(txtCI, "El CI es obligatorio"); esValido = false; }
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { erpNombre.SetError(txtNombre, "El Nombre es obligatorio"); esValido = false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { erpApellido.SetError(txtApellido, "El Apellido es obligatorio"); esValido = false; }
            return esValido;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                int idActual = 0;
                if (!esNuevo) idActual = Convert.ToInt32(dgvLista.CurrentRow.Cells["id"].Value);

                if (ClienteCln.ExisteCi(txtCI.Text, idActual))
                {
                    var inactivo = ClienteCln.obtenerInactivoPorCi(txtCI.Text);
                    if (inactivo != null && esNuevo)
                    {
                        if (MessageBox.Show("Este Carnet pertenece a un cliente que fue DADO DE BAJA.\n\n¿Desea REACTIVARLO?", "Reactivar Cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            inactivo.nombre = txtNombre.Text.Trim();
                            inactivo.apellido = txtApellido.Text.Trim();
                            inactivo.telefono = txtTelefono.Text.Trim();
                            inactivo.correo = txtCorreo.Text.Trim();
                            inactivo.estado = 1;
                            inactivo.usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin";
                            ClienteCln.modificar(inactivo);
                            listar();
                            btnCancelar.PerformClick();
                            MessageBox.Show("¡Cliente reactivado correctamente!", "::: Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        else { txtCI.Focus(); return; }
                    }
                    else
                    {
                        MessageBox.Show("Atención: CI ya registrado y ACTIVO.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCI.Focus(); return;
                    }
                }
                var cliente = new Cliente()
                {
                    ci = txtCI.Text.Trim(),
                    nombre = txtNombre.Text.Trim(),
                    apellido = txtApellido.Text.Trim(),
                    telefono = txtTelefono.Text.Trim(),
                    correo = txtCorreo.Text.Trim(),
                    usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin"
                };

                if (esNuevo)
                {
                    cliente.fechaRegistro = DateTime.Now;
                    cliente.estado = 1;
                    ClienteCln.crear(cliente);
                }
                else
                {
                    cliente.id = idActual;
                    ClienteCln.modificar(cliente);
                }

                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Cliente guardado correctamente", "::: Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null) return;
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;

            if (MessageBox.Show("¿Está seguro de DESHABILITAR a este cliente?\n\n(Se liberarán sus cupos y reservas, pero podrá recuperarlo más tarde desde la lista de inactivos)", "::: Deshabilitar Cliente :::", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string usuarioR = Util.usuario != null ? Util.usuario.nombre_usuario : "admin";


                limpiarCascadaCliente(id, usuarioR);


                ClienteCln.deshabilitar(id, usuarioR);

                listar();
                MessageBox.Show("Cliente deshabilitado temporalmente. Los cupos han sido liberados.", "::: Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null) return;
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;

            if (btnEliminar.Text == "Eliminar")
            {
                if (MessageBox.Show("¿Está seguro de ELIMINAR definitivamente a este cliente?\n\nESTA ACCIÓN NO SE PUEDE DESHACER. El cliente perderá sus cupos, reservas y NO PODRÁ SER RECUPERADO.", "::: ELIMINACIÓN PERMANENTE :::", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    string usuarioR = Util.usuario != null ? Util.usuario.nombre_usuario : "admin";


                    limpiarCascadaCliente(id, usuarioR);


                    using (var db = new GimnasioEntities())
                    {
                        var clienteDB = db.Cliente.Find(id);
                        if (clienteDB != null)
                        {
                            clienteDB.estado = -2; 
                            clienteDB.usuarioRegistro = usuarioR;
                            db.SaveChanges();
                        }
                    }

                    listar();
                    MessageBox.Show("Cliente eliminado de forma permanente del sistema.", "::: Éxito :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else 
            {
                if (MessageBox.Show("¿Desea REACTIVAR a este cliente?", "::: Mensaje :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string usuarioR = Util.usuario != null ? Util.usuario.nombre_usuario : "admin";
                    ClienteCln.reactivar(id, usuarioR);
                    cbxInactivos.Checked = false;
                    listar();
                }
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
        private void cbxInactivos_CheckedChanged(object sender, EventArgs e) => listar();
        private void limpiarCascadaCliente(int idCliente, string usuarioR)
        {
            using (var db = new GimnasioEntities())
            {
                
                var reservasActivas = db.Reserva.Where(r => r.id_cliente == idCliente && r.estado != -1 && r.estado_reserva != "Anulada").ToList();
                foreach (var reserva in reservasActivas)
                {
                    reserva.estado = -1;
                    reserva.estado_reserva = "Anulada";
                    reserva.usuarioRegistro = usuarioR;


                    var horario = db.HorarioClase.Find(reserva.id_horarioclase);
                    if (horario != null && horario.cupos_reservados > 0)
                    {
                        horario.cupos_reservados--;
                    }
                }

                var accesosCliente = db.RegistroAcceso.Where(a => a.id_cliente == idCliente && a.estado != -1).ToList();
                foreach (var acceso in accesosCliente)
                {
                    acceso.estado = -1;
                    acceso.usuarioRegistro = usuarioR;
                }

                db.SaveChanges();
            }
        }
    }
}