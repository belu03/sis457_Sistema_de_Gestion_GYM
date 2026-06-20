using CadGimnasio;
using ClnGimnasio;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FrmServicio : Form
    {
        private bool esNuevo = false;

        public FrmServicio()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ServicioCln.listarPa(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["nombre"].HeaderText = "Nombre del Servicio";
            dgvLista.Columns["descripcion"].HeaderText = "Descripción";
            dgvLista.Columns["capacidad_maxima"].HeaderText = "Capacidad Máx.";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["nombre"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }

        private void FrmServicio_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1264, 440);
            gbxLista.Location = new Point(20, 110);
            gbxLista.Size = new Size(1224, 240);
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Location = new Point(20, 360);
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxDatos.Visible = false;

            listar();
            EstilosUI.FormatearGrilla(dgvLista);
        }

        private void btnBuscar_Click(object sender, EventArgs e) => listar();

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        private void limpiar()
        {
            txtNombre.Clear(); txtDescripcion.Clear(); nudCapacidad.Value = 0;
            erpNombre.Clear(); erpCapacidad.Clear();
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

            esNuevo = true;
            pnlAcciones.Enabled = false;
            limpiar();
            txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null) return;

            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.ClientSize = new Size(1264, 680);
            gbxDatos.Location = new Point(20, 430);
            gbxDatos.Size = new Size(1224, 210);
            gbxDatos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxDatos.Visible = true;
            gbxDatos.BringToFront();

            esNuevo = false;
            pnlAcciones.Enabled = false;
            erpNombre.Clear(); erpCapacidad.Clear();

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var servicio = ServicioCln.obtenerUno(id);
            txtNombre.Text = servicio.nombre;
            txtDescripcion.Text = servicio.descripcion;
            nudCapacidad.Value = servicio.capacidad_maxima;
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gbxDatos.Visible = false;
            this.ClientSize = new Size(1264, 440);
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            erpNombre.Clear();
            erpCapacidad.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                erpNombre.SetError(txtNombre, "Obligatorio");
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show(
                    "Debe ingresar una descripción para el servicio.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtDescripcion.Focus();
                return;
            }

            if (nudCapacidad.Value <= 0)
            {
                erpCapacidad.SetError(nudCapacidad, "Mayor a 0");
                nudCapacidad.Focus();
                return;
            }

            if (esNuevo)
            {
                var lista = ServicioCln.listarPa("");

                var servicioExistente = lista.FirstOrDefault(x =>
                    x.nombre.Trim().ToUpper() ==
                    txtNombre.Text.Trim().ToUpper());

                if (servicioExistente != null)
                {
                    MessageBox.Show(
                        $"El servicio {servicioExistente.nombre} ya se encuentra registrado con capacidad máxima de {servicioExistente.capacidad_maxima} personas.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtNombre.Focus();
                    return;
                }
            }

            var servicio = new Servicio()
            {
                nombre = txtNombre.Text.Trim(),
                descripcion = txtDescripcion.Text.Trim(),
                capacidad_maxima = (int)nudCapacidad.Value,
                usuarioRegistro = Util.usuario != null
                    ? Util.usuario.nombre_usuario
                    : "admin"
            };

            if (esNuevo)
            {
                servicio.fechaRegistro = DateTime.Now;
                servicio.estado = 1;
                ServicioCln.crear(servicio);
            }
            else
            {
                servicio.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                ServicioCln.modificar(servicio);
            }

            listar();
            btnCancelar.PerformClick();

            MessageBox.Show(
                "Servicio guardado correctamente.",
                "::: Mensaje :::",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            string nombre = dgvLista.CurrentRow.Cells["nombre"].Value.ToString();
            if (MessageBox.Show($"¿Eliminar {nombre}?", "::: Mensaje :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ServicioCln.eliminar(id, Util.usuario != null ? Util.usuario.nombre_usuario : "admin");
                listar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}