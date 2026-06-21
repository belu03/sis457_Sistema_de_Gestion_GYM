using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CadGimnasio;
using ClnGimnasio;

namespace CpGimnasio
{
    public partial class FrmInscripcion : Form
    {
        private Cliente clienteActual = null;

        public FrmInscripcion()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = InscripcionCln.listarPa(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["id_cliente"].Visible = false;
            dgvLista.Columns["id_membresia"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;

            dgvLista.Columns["ci"].HeaderText = "CI Cliente";
            dgvLista.Columns["nombre"].HeaderText = "Nombre";
            dgvLista.Columns["apellido"].HeaderText = "Apellido";
            dgvLista.Columns["tipo_membresia"].HeaderText = "Plan";
            dgvLista.Columns["fecha_inicio"].HeaderText = "Inicio";
            dgvLista.Columns["fecha_fin"].HeaderText = "Vencimiento";
            dgvLista.Columns["monto_pagado"].HeaderText = "Monto (Bs)";
            dgvLista.Columns["metodo_pago"].HeaderText = "Método";
            dgvLista.Columns["estado_inscripcion"].HeaderText = "Estado";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["ci"];
            btnEliminar.Enabled = lista.Count > 0;
        }

        private void cargarCombos()
        {
            cbxMembresia.DataSource = MembresiaCln.listar();
            cbxMembresia.DisplayMember = "tipo";
            cbxMembresia.ValueMember = "id";
            cbxMembresia.SelectedIndex = -1;

            cbxMetodoPago.Items.Clear();
            cbxMetodoPago.Items.AddRange(new string[] { "Efectivo", "QR", "Tarjeta", "Transferencia" });
        }

        private void FrmInscripcion_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1264, 440);
            gbxLista.Location = new Point(20, 110);
            gbxLista.Size = new Size(1224, 240);
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Location = new Point(20, 360);
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxDatos.Visible = false;

            lblMontoRecibido.Visible = false;
            txtMontoRecibido.Visible = false;
            lblCambio.Visible = false;
            lblValorCambio.Visible = false;

            listar();
            cargarCombos();
            dtpInicio.MinDate = DateTime.Today;
            EstilosUI.FormatearGrilla(dgvLista);
        }

        private void btnBuscar_Click(object sender, EventArgs e) => listar();

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.ClientSize = new Size(1264, 680);
            gbxDatos.Location = new Point(20, 430);
            gbxDatos.Size = new Size(1224, 210);
            gbxDatos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxDatos.Visible = true;
            gbxDatos.BringToFront();

            pnlAcciones.Enabled = false;
            limpiar();
            txtCI.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gbxDatos.Visible = false;
            this.ClientSize = new Size(1264, 440);
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Enabled = true;
        }

        private void limpiar()
        {
            clienteActual = null;
            txtCI.Clear(); txtNombre.Clear(); txtApellido.Clear();
            cbxMembresia.SelectedIndex = -1; cbxMetodoPago.SelectedIndex = -1;
            dtpInicio.Value = DateTime.Now; lblMonto.Text = "0.00 Bs"; lblEstadoMembresia.Text = "";
            erpCI.Clear(); erpMembresia.Clear(); erpPago.Clear();
        }

        private void btnBuscarCI_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCI.Text)) { erpCI.SetError(txtCI, "Ingrese CI"); return; }
            erpCI.Clear();

            clienteActual = ClienteCln.listar().FirstOrDefault(c => c.ci == txtCI.Text.Trim());

            if (clienteActual != null)
            {
                txtNombre.Text = clienteActual.nombre;
                txtApellido.Text = clienteActual.apellido;

                var ultimaInscripcion = InscripcionCln.listarPa(clienteActual.ci)
                                        .FirstOrDefault(i => i.estado_inscripcion == "Activa" && i.fecha_fin >= DateTime.Now.Date);

                if (ultimaInscripcion != null)
                {
                    int dias = (ultimaInscripcion.fecha_fin - DateTime.Now.Date).Days;
                    lblEstadoMembresia.Text = $"PLAN ACTIVO: Quedan {dias} días.";
                    lblEstadoMembresia.ForeColor = ColorTranslator.FromHtml("#63FF47");

                    RegistroAccesoCln.crear(new RegistroAcceso
                    {
                        id_cliente = clienteActual.id,
                        fecha_hora = DateTime.Now,
                        tipo = "Entrada",
                        usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin",
                        fechaRegistro = DateTime.Now,
                        estado = 1
                    });

                    MessageBox.Show($"Check-In registrado. Le quedan {dias} días.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCancelar.PerformClick();
                }
                else
                {
                    lblEstadoMembresia.Text = "PLAN VENCIDO. Requiere renovación.";
                    lblEstadoMembresia.ForeColor = ColorTranslator.FromHtml("#F73B14");
                }
            }
            else
            {
                lblEstadoMembresia.Text = "CLIENTE NUEVO. Complete datos.";
                lblEstadoMembresia.ForeColor = ColorTranslator.FromHtml("#ECFF4A");
                txtNombre.Focus();
            }
        }

        private void cbxMembresia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMembresia.SelectedValue != null && int.TryParse(cbxMembresia.SelectedValue.ToString(), out int idMem))
            {
                var mem = MembresiaCln.obtenerUno(idMem);
                if (mem != null) lblMonto.Text = $"{mem.precio:0.00} Bs";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCI.Text) || string.IsNullOrWhiteSpace(txtNombre.Text)) { MessageBox.Show("CI y Nombre obligatorios"); return; }
            if (cbxMembresia.SelectedValue == null || string.IsNullOrWhiteSpace(cbxMetodoPago.Text)) { MessageBox.Show("Membresía y Pago obligatorios"); return; }
            if (dtpInicio.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show(
                    "La fecha de inicio no puede ser anterior a la fecha actual.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                dtpInicio.Focus();
                return;
            }
            if (cbxMetodoPago.Text == "Efectivo")
            {
                decimal montoPlan = 0;
                decimal.TryParse(
                    lblMonto.Text.Replace("Bs", "").Trim(),
                    out montoPlan);

                decimal montoRecibido = 0;

                if (!decimal.TryParse(txtMontoRecibido.Text, out montoRecibido))
                {
                    MessageBox.Show(
                        "Debe ingresar el monto recibido.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMontoRecibido.Focus();
                    return;
                }

                if (montoRecibido < montoPlan)
                {
                    MessageBox.Show(
                        "El monto recibido no puede ser menor al costo del plan.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtMontoRecibido.Focus();
                    return;
                }
            }
            string usuarioApp = Util.usuario != null ? Util.usuario.nombre_usuario : "admin";

            if (clienteActual == null)
            {
                if (ClienteCln.ExisteCi(txtCI.Text.Trim()))
                {
                    MessageBox.Show("Cliente dado de baja. Vaya a 'Clientes' para reactivarlo.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                clienteActual = new Cliente { ci = txtCI.Text.Trim(), nombre = txtNombre.Text.Trim(), apellido = txtApellido.Text.Trim(), usuarioRegistro = usuarioApp, fechaRegistro = DateTime.Now, estado = 1 };
                clienteActual.id = ClienteCln.crear(clienteActual);
            }
            else
            {
                clienteActual.nombre = txtNombre.Text.Trim(); clienteActual.apellido = txtApellido.Text.Trim(); clienteActual.usuarioRegistro = usuarioApp;
                ClienteCln.modificar(clienteActual);
            }

            var mem = MembresiaCln.obtenerUno((int)cbxMembresia.SelectedValue);
            var inscripcion = new Inscripcion
            {
                id_cliente = clienteActual.id,
                id_membresia = mem.id,
                fecha_inicio = dtpInicio.Value.Date,
                fecha_fin = dtpInicio.Value.Date.AddDays(mem.duracion_dias),
                monto_pagado = mem.precio,
                metodo_pago = cbxMetodoPago.Text,
                fecha_transaccion = DateTime.Now,
                estado_inscripcion = "Activa",
                usuarioRegistro = usuarioApp,
                fechaRegistro = DateTime.Now,
                estado = 1
            };
            InscripcionCln.crear(inscripcion);
            RegistroAccesoCln.crear(new RegistroAcceso { id_cliente = clienteActual.id, fecha_hora = DateTime.Now, tipo = "Entrada", usuarioRegistro = usuarioApp, fechaRegistro = DateTime.Now, estado = 1 });

            listar();
            btnCancelar.PerformClick();
            MessageBox.Show("Venta registrada.", "::: Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            if (MessageBox.Show("¿Anular esta inscripción?", "::: Mensaje :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InscripcionCln.anular(id, Util.usuario != null ? Util.usuario.nombre_usuario : "admin");
                listar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();

        private void cbxMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esEfectivo = cbxMetodoPago.Text == "Efectivo";

            lblMontoRecibido.Visible = esEfectivo;
            txtMontoRecibido.Visible = esEfectivo;
            lblCambio.Visible = esEfectivo;
            lblValorCambio.Visible = esEfectivo;
        }

        private void txtMontoRecibido_TextChanged(object sender, EventArgs e)
        {
            decimal montoPlan = 0;

            decimal.TryParse(
                lblMonto.Text.Replace("Bs", "").Trim(),
                out montoPlan);

            decimal recibido = 0;

            if (decimal.TryParse(txtMontoRecibido.Text, out recibido))
            {
                decimal cambio = recibido - montoPlan;

                lblValorCambio.Text =
                    cambio >= 0
                    ? $"{cambio:0.00} Bs"
                    : "0.00 Bs";
            }
            else
            {
                lblValorCambio.Text = "0.00 Bs";
            }
        }
        private void txtMontoRecibido_KeyPress(
             object sender,
             KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}