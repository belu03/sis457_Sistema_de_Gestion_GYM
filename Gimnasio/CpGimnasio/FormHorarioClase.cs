using CadGimnasio;
using ClnGimnasio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormHorarioClase : Form
    {
        private bool esNuevo = false;
        private int idSeleccionado = 0;

        // Datos base en memoria (mejora de rendimiento)
        private List<Servicio> servicios;
        private List<Entrenador> entrenadores;

        public FormHorarioClase()
        {
            InitializeComponent();
        }

        private void FormHorarioClase_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.gym_fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.White;
            SetLabelsTransparent();
            pbLogo.Image = Properties.Resources.HORARIO;
            AplicarEstilosVisuales();

            // Cargar datos base una sola vez
            servicios = Repositorio<Servicio>.Listar();
            entrenadores = Repositorio<Entrenador>.Listar();

            CargarCombos();
            ListarHorarios();
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

        private void CargarCombos()
        {
            string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" };
            cmbDia.Items.AddRange(dias);
            cmbDia.DropDownStyle = ComboBoxStyle.DropDownList;

            // Usamos los datos en memoria
            var serviciosActivos = servicios.Where(s => s.activo == true).ToList();
            cmbServicio.DataSource = serviciosActivos;
            cmbServicio.DisplayMember = "nombre";
            cmbServicio.ValueMember = "id";
            cmbServicio.DropDownStyle = ComboBoxStyle.DropDownList;

            var entrenadoresActivos = entrenadores.Where(e => e.activo == true).ToList();
            cmbEntrenador.DataSource = entrenadoresActivos;
            cmbEntrenador.DisplayMember = "nombre";
            cmbEntrenador.ValueMember = "id";
            cmbEntrenador.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ListarHorarios(string filtro = "")
        {
            var horarios = Repositorio<HorarioClase>.Listar();

            var lista = horarios.Where(h => h.activo == true).Select(h => new
            {
                h.id,
                Servicio = servicios.FirstOrDefault(s => s.id == h.id_servicio)?.nombre,
                Entrenador = entrenadores.FirstOrDefault(e => e.id == h.id_entrenador)?.nombre + " " +
                             entrenadores.FirstOrDefault(e => e.id == h.id_entrenador)?.apellido,
                h.dia_semana,
                Inicio = h.hora_inicio,
                Fin = h.hora_fin
                // Cupos eliminado de aquí
            }).OrderBy(x => x.dia_semana).ThenBy(x => x.Inicio).ToList();

            if (!string.IsNullOrEmpty(filtro))
                lista = lista.Where(x => x.Servicio.ToLower().Contains(filtro.ToLower())).ToList();

            dgvLista.DataSource = lista;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvLista.Columns["id"] != null) dgvLista.Columns["id"].Visible = false;
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
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (esNuevo)
            {
                var h = new HorarioClase
                {
                    id_servicio = Convert.ToInt32(cmbServicio.SelectedValue),
                    id_entrenador = Convert.ToInt32(cmbEntrenador.SelectedValue),
                    dia_semana = cmbDia.Text,
                    hora_inicio = dtpHoraInicio.Value.TimeOfDay,
                    hora_fin = dtpHoraFin.Value.TimeOfDay,
                    cupos_reservados = 0,
                    activo = true
                };
                Repositorio<HorarioClase>.Crear(h);
            }
            else
            {
                var h = Repositorio<HorarioClase>.ObtenerUno(idSeleccionado);
                h.id_servicio = Convert.ToInt32(cmbServicio.SelectedValue);
                h.id_entrenador = Convert.ToInt32(cmbEntrenador.SelectedValue);
                h.dia_semana = cmbDia.Text;
                h.hora_inicio = dtpHoraInicio.Value.TimeOfDay;
                h.hora_fin = dtpHoraFin.Value.TimeOfDay;
                Repositorio<HorarioClase>.Modificar(h);
            }

            ListarHorarios();
            CancelarOperacion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            esNuevo = false;
            var h = Repositorio<HorarioClase>.ObtenerUno(idSeleccionado);
            cmbServicio.SelectedValue = h.id_servicio;
            cmbEntrenador.SelectedValue = h.id_entrenador;
            cmbDia.Text = h.dia_semana;
            dtpHoraInicio.Value = DateTime.Today.Add(h.hora_inicio);
            dtpHoraFin.Value = DateTime.Today.Add(h.hora_fin);

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
            if (MessageBox.Show("¿Eliminar este horario?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var h = Repositorio<HorarioClase>.ObtenerUno(idSeleccionado);
                h.activo = false;
                Repositorio<HorarioClase>.Modificar(h);
                ListarHorarios();
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
            if (cmbServicio.Items.Count > 0) cmbServicio.SelectedIndex = 0;
            if (cmbEntrenador.Items.Count > 0) cmbEntrenador.SelectedIndex = 0;
            if (cmbDia.Items.Count > 0) cmbDia.SelectedIndex = 0;
            dtpHoraInicio.Value = DateTime.Today.AddHours(8);
            dtpHoraFin.Value = DateTime.Today.AddHours(9);
            erpHorario.Clear();
        }

        private void HabilitarCampos(bool habilitar)
        {
            cmbServicio.Enabled = habilitar;
            cmbEntrenador.Enabled = habilitar;
            cmbDia.Enabled = habilitar;
            dtpHoraInicio.Enabled = habilitar;
            dtpHoraFin.Enabled = habilitar;
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            erpHorario.Clear();
            if (cmbServicio.SelectedValue == null) { erpHorario.SetError(cmbServicio, "Requerido"); ok = false; }
            if (cmbEntrenador.SelectedValue == null) { erpHorario.SetError(cmbEntrenador, "Requerido"); ok = false; }
            if (string.IsNullOrWhiteSpace(cmbDia.Text)) { erpHorario.SetError(cmbDia, "Requerido"); ok = false; }
            if (dtpHoraInicio.Value.TimeOfDay >= dtpHoraFin.Value.TimeOfDay)
            {
                erpHorario.SetError(dtpHoraFin, "La hora fin debe ser posterior al inicio");
                ok = false;
            }
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

        private void txtBuscar_TextChanged(object sender, EventArgs e) => ListarHorarios(txtBuscar.Text.Trim());
    }
}