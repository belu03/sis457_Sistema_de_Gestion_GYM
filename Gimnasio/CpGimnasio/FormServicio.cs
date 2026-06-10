using CadGimnasio;
using ClnGimnasio;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormServicio : Form
    {
        private bool esNuevo = false;
        private int idSeleccionado = 0;

        public FormServicio()
        {
            InitializeComponent();
        }

        private void FormServicio_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.gym_fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.White;
            SetLabelsTransparent();
            pbLogo.Image = Properties.Resources.SERVICIOS;
            AplicarEstilosVisuales();
            ListarServicios();
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

        private void ListarServicios(string filtro = "")
        {
            var lista = Repositorio<Servicio>.Listar().Where(s => s.activo == true).ToList();
            if (!string.IsNullOrEmpty(filtro))
                lista = lista.Where(s => s.nombre.Contains(filtro)).ToList();

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

            int nuevaCapacidad = int.Parse(txtCapacidad.Text.Trim());

            // Validación adicional al editar: la capacidad no puede ser menor que las reservas futuras
            if (!esNuevo)
            {
                DateTime hoy = DateTime.Today;
                // Obtener todos los horarios activos de este servicio
                var horarios = Repositorio<HorarioClase>.Listar()
                    .Where(h => h.id_servicio == idSeleccionado && h.activo == true)
                    .Select(h => h.id)
                    .ToList();

                if (horarios.Any())
                {
                    // Contar reservas confirmadas para esos horarios en fecha >= hoy
                    int maxReservas = Repositorio<Reserva>.Listar()
                        .Where(r => horarios.Contains(r.id_horarioclase)
                                 && r.fecha_reserva >= hoy
                                 && r.estado == "Confirmada")
                        .GroupBy(r => r.id_horarioclase)
                        .Max(g => g.Count());

                    if (maxReservas > nuevaCapacidad)
                    {
                        MessageBox.Show(
                            $"No se puede reducir la capacidad a {nuevaCapacidad} porque hay un horario con {maxReservas} reservas confirmadas.\n" +
                            "Primero cancele o reubique las reservas excedentes.",
                            "Capacidad insuficiente",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            if (esNuevo)
            {
                var serv = new Servicio
                {
                    nombre = txtNombre.Text.Trim(),
                    descripcion = txtDescripcion.Text.Trim(),
                    capacidad_maxima = nuevaCapacidad,
                    activo = true
                };
                Repositorio<Servicio>.Crear(serv);
            }
            else
            {
                var serv = Repositorio<Servicio>.ObtenerUno(idSeleccionado);
                serv.nombre = txtNombre.Text.Trim();
                serv.descripcion = txtDescripcion.Text.Trim();
                serv.capacidad_maxima = nuevaCapacidad;
                Repositorio<Servicio>.Modificar(serv);
            }

            ListarServicios();
            CancelarOperacion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            esNuevo = false;
            var s_db = Repositorio<Servicio>.ObtenerUno(idSeleccionado);
            txtNombre.Text = s_db.nombre;
            txtDescripcion.Text = s_db.descripcion;
            txtCapacidad.Text = s_db.capacidad_maxima.ToString();
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
            if (MessageBox.Show("¿Eliminar este servicio?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var s_db = Repositorio<Servicio>.ObtenerUno(idSeleccionado);
                s_db.activo = false;
                Repositorio<Servicio>.Modificar(s_db);
                ListarServicios();
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
            txtDescripcion.Clear();
            txtCapacidad.Clear();
            erpServicio.Clear();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            txtCapacidad.Enabled = habilitar;
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            erpServicio.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) { erpServicio.SetError(txtNombre, "Requerido"); ok = false; }
            if (!int.TryParse(txtCapacidad.Text, out _)) { erpServicio.SetError(txtCapacidad, "Debe ser un número válido"); ok = false; }
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

        private void txtBuscar_TextChanged(object sender, EventArgs e) => ListarServicios(txtBuscar.Text.Trim());
    }
}