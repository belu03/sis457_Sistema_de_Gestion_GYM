using System;
using System.Drawing;
using System.Windows.Forms;
using CadGimnasio;
using ClnGimnasio;

namespace CpGimnasio
{
    public partial class FrmEntrenador : Form
    {
        private bool esNuevo = false;

        public FrmEntrenador()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = EntrenadorCln.listarPa(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["nombre"].HeaderText = "Nombres";
            dgvLista.Columns["apellido"].HeaderText = "Apellidos";
            dgvLista.Columns["telefono"].HeaderText = "Teléfono";
            dgvLista.Columns["especialidad"].HeaderText = "Especialidad";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["nombre"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }

        private void FrmEntrenador_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1264, 440);
            gbxLista.Location = new Point(20, 110);
            gbxLista.Size = new Size(1224, 240);
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Location = new Point(20, 360);
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxDatos.Visible = false;

            cbxEspecialidad.Items.Clear();
            cbxEspecialidad.Items.AddRange(new string[] { 
                "Musculación", 
                "Crossfit", 
                "Cardio / Spinning",
                "Zumba / Aeróbicos", 
                "Entrenador Personal" ,
                "Yoga",
                "Pilates",
                "Natación",
                "Artes Marciales",
                "Funcional",
                "Nutrición Deportiva",
                "Rehabilitación Física",
                "Powerlifting",
                "Calistenia",
                "HIIT (Entrenamiento de Alta Intensidad)",
                "Entrenamiento de Fuerza",
                "Entrenamiento de Resistencia",
                "Entrenamiento de Aumento de Masa Muscular",
                "Entrenamiento de Pérdida de Peso",
                "Entrenamiento Deportivo (Atletas)",
                "Entrenamiento de Alto Rendimiento",
                "Movilidad y Flexibilidad",
                "Stretching (Estiramiento)",
                "Acondicionamiento Físico General"
            });
            cbxEspecialidad.SelectedIndex = 0;

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
            txtNombre.Clear(); txtApellido.Clear(); txtTelefono.Clear();
            cbxEspecialidad.SelectedIndex = 0;
            erpNombre.Clear(); erpApellido.Clear();
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
            erpNombre.Clear(); erpApellido.Clear();

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var entrenador = EntrenadorCln.obtenerUno(id);
            txtNombre.Text = entrenador.nombre;
            txtApellido.Text = entrenador.apellido;
            txtTelefono.Text = entrenador.telefono;
            cbxEspecialidad.Text = entrenador.especialidad;
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
            erpNombre.Clear(); erpApellido.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { erpNombre.SetError(txtNombre, "Obligatorio"); return; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { erpApellido.SetError(txtApellido, "Obligatorio"); return; }

            var entrenador = new Entrenador()
            {
                nombre = txtNombre.Text.Trim(),
                apellido = txtApellido.Text.Trim(),
                telefono = txtTelefono.Text.Trim(),
                especialidad = cbxEspecialidad.SelectedItem.ToString(),
                usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin"
            };

            if (esNuevo)
            {
                entrenador.fechaRegistro = DateTime.Now;
                entrenador.estado = 1;
                EntrenadorCln.crear(entrenador);
            }
            else
            {
                entrenador.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                EntrenadorCln.modificar(entrenador);
            }

            listar();
            btnCancelar.PerformClick();
            MessageBox.Show("Entrenador guardado correctamente", "::: Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            string nombre = $"{dgvLista.CurrentRow.Cells["nombre"].Value} {dgvLista.CurrentRow.Cells["apellido"].Value}";
            if (MessageBox.Show($"¿Dar de baja a {nombre}?", "::: Mensaje :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EntrenadorCln.eliminar(id, Util.usuario != null ? Util.usuario.nombre_usuario : "admin");
                listar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}