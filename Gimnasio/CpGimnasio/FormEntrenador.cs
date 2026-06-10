using CadGimnasio;
using ClnGimnasio;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormEntrenador : Form
    {
        private bool esNuevo = false;
        private int idSeleccionado = 0;

        public FormEntrenador()
        {
            InitializeComponent();
        }

        private void FormEntrenador_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.gym_fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.White;
            SetLabelsTransparent();
            pbLogo.Image = Properties.Resources.SERVICIOS; // Temporal (no hay ENTRENADOR.png)
            AplicarEstilosVisuales();
            ListarEntrenadores();
            EstadoInicialBotones();
        }

        private void SetLabelsTransparent()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Label) c.BackColor = Color.Transparent;
                if (c is Panel || c is GroupBox) SetLabelsTransparentRecursive(c);
            }
        }
        private void SetLabelsTransparentRecursive(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label) c.BackColor = Color.Transparent;
                if (c.HasChildren) SetLabelsTransparentRecursive(c);
            }
        }

        private void AplicarEstilosVisuales()
        {
            ConfigurarBoton(btnNuevo, Color.FromArgb(37, 99, 235));
            ConfigurarBoton(btnGuardar, Color.FromArgb(16, 185, 129));
            ConfigurarBoton(btnEditar, Color.FromArgb(245, 158, 11));
            ConfigurarBoton(btnEliminar, Color.FromArgb(225, 29, 72));
            ConfigurarBoton(btnCancelar, Color.FromArgb(75, 85, 99));

            dgvLista.BackgroundColor = Color.White;
            dgvLista.BorderStyle = BorderStyle.None;
            dgvLista.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLista.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 242, 254);
            dgvLista.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvLista.RowHeadersVisible = false;
            dgvLista.EnableHeadersVisualStyles = false;
            dgvLista.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 41, 55);
            dgvLista.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLista.ColumnHeadersHeight = 35;
        }

        private void ConfigurarBoton(Button btn, Color backColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Image = null;
        }

        private void ListarEntrenadores(string filtro = "")
        {
            var lista = Repositorio<Entrenador>.Listar().Where(e => e.activo == true).ToList();
            if (!string.IsNullOrEmpty(filtro))
                lista = lista.Where(e => e.nombre.Contains(filtro) || e.apellido.Contains(filtro)).ToList();

            dgvLista.DataSource = lista;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvLista.Columns["id"] != null) dgvLista.Columns["id"].Visible = false;
            if (dgvLista.Columns["activo"] != null) dgvLista.Columns["activo"].Visible = false;
            if (dgvLista.Columns["HorarioClase"] != null) dgvLista.Columns["HorarioClase"].Visible = false;
        }

        private void EstadoInicialBotones()
        {
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
            btnNuevo.Enabled = true;
            HabilitarCampos(false);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            LimpiarCampos();
            HabilitarCampos(true);
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (esNuevo)
            {
                var entrenador = new Entrenador
                {
                    nombre = txtNombre.Text.Trim(),
                    apellido = txtApellido.Text.Trim(),
                    telefono = txtTelefono.Text.Trim(),
                    especialidad = txtEspecialidad.Text.Trim(),
                    activo = true
                };
                Repositorio<Entrenador>.Crear(entrenador);
            }
            else
            {
                var entrenador = Repositorio<Entrenador>.ObtenerUno(idSeleccionado);
                entrenador.nombre = txtNombre.Text.Trim();
                entrenador.apellido = txtApellido.Text.Trim();
                entrenador.telefono = txtTelefono.Text.Trim();
                entrenador.especialidad = txtEspecialidad.Text.Trim();
                Repositorio<Entrenador>.Modificar(entrenador);
            }

            ListarEntrenadores();
            CancelarOperacion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            esNuevo = false;
            var e_db = Repositorio<Entrenador>.ObtenerUno(idSeleccionado);
            txtNombre.Text = e_db.nombre;
            txtApellido.Text = e_db.apellido;
            txtTelefono.Text = e_db.telefono;
            txtEspecialidad.Text = e_db.especialidad;
            HabilitarCampos(true);
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            if (MessageBox.Show("¿Eliminar este entrenador?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var e_db = Repositorio<Entrenador>.ObtenerUno(idSeleccionado);
                e_db.activo = false;
                Repositorio<Entrenador>.Modificar(e_db);
                ListarEntrenadores();
                CancelarOperacion();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => CancelarOperacion();

        private void CancelarOperacion()
        {
            esNuevo = false;
            idSeleccionado = 0;
            LimpiarCampos();
            EstadoInicialBotones();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtEspecialidad.Clear();
            erpEntrenador.Clear();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtApellido.Enabled = habilitar;
            txtTelefono.Enabled = habilitar;
            txtEspecialidad.Enabled = habilitar;
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            erpEntrenador.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { erpEntrenador.SetError(txtNombre, "Requerido"); ok = false; }
            if (string.IsNullOrWhiteSpace(txtApellido.Text)) { erpEntrenador.SetError(txtApellido, "Requerido"); ok = false; }
            return ok;
        }

        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idSeleccionado = Convert.ToInt32(dgvLista.Rows[e.RowIndex].Cells["id"].Value);
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) => ListarEntrenadores(txtBuscar.Text.Trim());
    }
}