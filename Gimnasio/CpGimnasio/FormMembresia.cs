using CadGimnasio;
using ClnGimnasio;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormMembresia : Form
    {
        private bool esNuevo = false;
        private int idSeleccionado = 0;

        public FormMembresia()
        {
            InitializeComponent();
        }

        private void FormMembresia_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.gym_fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.White;
            SetLabelsTransparent();
            pbLogo.Image = Properties.Resources.MEMBRESIA;
            AplicarEstilosVisuales();
            ListarMembresias();
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

        private void ListarMembresias(string filtro = "")
        {
            var lista = Repositorio<Membresia>.Listar().Where(m => m.activo == true).ToList();
            if (!string.IsNullOrEmpty(filtro))
                lista = lista.Where(m => m.tipo.Contains(filtro)).ToList();

            dgvLista.DataSource = lista;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvLista.Columns["id"] != null) dgvLista.Columns["id"].Visible = false;
            if (dgvLista.Columns["activo"] != null) dgvLista.Columns["activo"].Visible = false;
            if (dgvLista.Columns["Inscripcion"] != null) dgvLista.Columns["Inscripcion"].Visible = false;
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
            txtTipo.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (esNuevo)
            {
                var mem = new Membresia
                {
                    tipo = txtTipo.Text.Trim(),
                    precio = decimal.Parse(txtPrecio.Text.Trim()),
                    duracion_dias = int.Parse(txtDuracion.Text.Trim()),
                    activo = true
                };
                Repositorio<Membresia>.Crear(mem);
            }
            else
            {
                var mem = Repositorio<Membresia>.ObtenerUno(idSeleccionado);
                mem.tipo = txtTipo.Text.Trim();
                mem.precio = decimal.Parse(txtPrecio.Text.Trim());
                mem.duracion_dias = int.Parse(txtDuracion.Text.Trim());
                Repositorio<Membresia>.Modificar(mem);
            }

            ListarMembresias();
            CancelarOperacion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            esNuevo = false;
            var m_db = Repositorio<Membresia>.ObtenerUno(idSeleccionado);
            txtTipo.Text = m_db.tipo;
            txtPrecio.Text = m_db.precio.ToString("0.00");
            txtDuracion.Text = m_db.duracion_dias.ToString();
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
            if (MessageBox.Show("¿Eliminar este plan de membresía?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var m_db = Repositorio<Membresia>.ObtenerUno(idSeleccionado);
                m_db.activo = false;
                Repositorio<Membresia>.Modificar(m_db);
                ListarMembresias();
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
            txtTipo.Clear();
            txtPrecio.Clear();
            txtDuracion.Clear();
            erpMembresia.Clear();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtTipo.Enabled = habilitar;
            txtPrecio.Enabled = habilitar;
            txtDuracion.Enabled = habilitar;
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            erpMembresia.Clear();
            if (string.IsNullOrWhiteSpace(txtTipo.Text)) { erpMembresia.SetError(txtTipo, "Requerido"); ok = false; }
            if (!decimal.TryParse(txtPrecio.Text, out _)) { erpMembresia.SetError(txtPrecio, "Precio inválido"); ok = false; }
            if (!int.TryParse(txtDuracion.Text, out _)) { erpMembresia.SetError(txtDuracion, "Días inválidos"); ok = false; }
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

        private void txtBuscar_TextChanged(object sender, EventArgs e) => ListarMembresias(txtBuscar.Text.Trim());
    }
}