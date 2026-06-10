using CadGimnasio;
using ClnGimnasio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormAgenda : Form
    {
        private int idClaseSeleccionada = 0;
        private List<Servicio> servicios;
        private List<Cliente> clientes;

        public FormAgenda()
        {
            InitializeComponent();
        }

        private void FormAgenda_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.gym_fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.White;
            SetLabelsTransparent();
            pbLogo.Image = Properties.Resources.RESERVA;
            ConfigurarEstilos();

            servicios = Repositorio<Servicio>.Listar();
            clientes = Repositorio<Cliente>.Listar();

            CargarFiltroDia();
            CargarClases();
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

        private void ConfigurarEstilos()
        {
            DataGridView[] tablas = { dgvClases, dgvReservas };
            foreach (var dgv in tablas)
            {
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgv.RowHeadersVisible = false;
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 41, 55);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersHeight = 35;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.ReadOnly = true;
                dgv.MultiSelect = false;
            }

            btnReservar.BackColor = Color.FromArgb(37, 99, 235);
            btnReservar.ForeColor = Color.White;
            btnReservar.FlatStyle = FlatStyle.Flat;
            btnReservar.FlatAppearance.BorderSize = 0;
            btnReservar.Cursor = Cursors.Hand;
            btnReservar.Image = null;

            btnGestionarHorarios.BackColor = Color.FromArgb(75, 85, 99);
            btnGestionarHorarios.ForeColor = Color.White;
            btnGestionarHorarios.FlatStyle = FlatStyle.Flat;
            btnGestionarHorarios.FlatAppearance.BorderSize = 0;
            btnGestionarHorarios.Cursor = Cursors.Hand;
            btnGestionarHorarios.Image = null;
        }

        private void CargarFiltroDia()
        {
            cmbFiltroDia.Items.Clear();
            cmbFiltroDia.Items.Add("Todos");
            cmbFiltroDia.Items.AddRange(new string[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" });
            cmbFiltroDia.SelectedIndex = 0;
            cmbFiltroDia.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroDia.SelectedIndexChanged += (s, ev) => CargarClases();
        }

        private void CargarClases()
        {
            string diaFiltro = cmbFiltroDia.SelectedItem?.ToString();
            bool todos = diaFiltro == "Todos";

            var hoy = DateTime.Today;
            var reservasHoy = Repositorio<Reserva>.Listar()
                                .Where(r => r.fecha_reserva == hoy && r.estado == "Confirmada")
                                .ToList();

            var query = Repositorio<HorarioClase>.Listar().Where(h => h.activo == true);
            if (!todos)
                query = query.Where(h => h.dia_semana == diaFiltro);

            var clases = query.Select(h => {
                var servicio = servicios.FirstOrDefault(s => s.id == h.id_servicio);
                int capacidad = servicio?.capacidad_maxima ?? 0;
                int ocupados = reservasHoy.Count(r => r.id_horarioclase == h.id);
                return new
                {
                    h.id,
                    Clase = servicio?.nombre,
                    Dia = h.dia_semana,
                    Hora = h.hora_inicio.ToString(@"hh\:mm"),
                    Cupos = $"{ocupados} / {capacidad}"
                };
            }).OrderBy(x => x.Dia).ThenBy(x => x.Hora).ToList();

            dgvClases.DataSource = clases;
            dgvClases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvClases.Columns["id"] != null) dgvClases.Columns["id"].Visible = false;

            idClaseSeleccionada = 0;
            dgvReservas.DataSource = null;
            lblClaseSeleccionada.Text = "Seleccione una clase...";
        }

        private void dgvClases_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idClaseSeleccionada = Convert.ToInt32(dgvClases.Rows[e.RowIndex].Cells["id"].Value);
                string nombreClase = dgvClases.Rows[e.RowIndex].Cells["Clase"].Value.ToString();
                string horaClase = dgvClases.Rows[e.RowIndex].Cells["Hora"].Value.ToString();
                lblClaseSeleccionada.Text = $"Alumnos en {nombreClase} ({horaClase})";
                CargarAlumnosReservados();
            }
        }

        private void CargarAlumnosReservados()
        {
            if (idClaseSeleccionada == 0) return;

            DateTime hoy = DateTime.Today;
            var reservas = Repositorio<Reserva>.Listar()
                .Where(r => r.id_horarioclase == idClaseSeleccionada && r.fecha_reserva == hoy && r.estado == "Confirmada")
                .Select(r => {
                    var cli = clientes.FirstOrDefault(c => c.id == r.id_cliente);
                    return new
                    {
                        r.id,
                        Carnet = cli?.ci,
                        Alumno = cli?.nombre + " " + cli?.apellido
                    };
                }).ToList();

            dgvReservas.DataSource = reservas;
            dgvReservas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvReservas.Columns["id"] != null) dgvReservas.Columns["id"].Visible = false;
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (idClaseSeleccionada == 0)
            {
                MessageBox.Show("Primero haga clic en una clase de la lista izquierda.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCIReserva.Text))
            {
                MessageBox.Show("Ingrese el CI del alumno.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cliente = clientes.FirstOrDefault(c => c.ci == txtCIReserva.Text.Trim() && c.activo == true);
            if (cliente == null)
            {
                MessageBox.Show("No se encontró ningún cliente con ese CI.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime hoy = DateTime.Today;
            bool yaExiste = Repositorio<Reserva>.Listar().Any(r =>
                r.id_cliente == cliente.id &&
                r.id_horarioclase == idClaseSeleccionada &&
                r.fecha_reserva == hoy &&
                r.estado == "Confirmada");

            if (yaExiste)
            {
                MessageBox.Show("El alumno ya tiene un lugar reservado en esta clase para hoy.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ----- NUEVA VALIDACIÓN DE CUPO -----
            // Obtener el horario seleccionado y su servicio para conocer la capacidad máxima
            var horario = Repositorio<HorarioClase>.ObtenerUno(idClaseSeleccionada);
            if (horario != null)
            {
                var servicio = servicios.FirstOrDefault(s => s.id == horario.id_servicio);
                if (servicio != null)
                {
                    int capacidad = servicio.capacidad_maxima;
                    int ocupados = Repositorio<Reserva>.Listar()
                        .Count(r => r.id_horarioclase == idClaseSeleccionada
                                 && r.fecha_reserva == hoy
                                 && r.estado == "Confirmada");
                    if (ocupados >= capacidad)
                    {
                        MessageBox.Show("No hay cupos disponibles. La clase está llena.", "Cupo completo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            Repositorio<Reserva>.Crear(new Reserva
            {
                id_cliente = cliente.id,
                id_horarioclase = idClaseSeleccionada,
                fecha_reserva = hoy,
                asistio = false,
                estado = "Confirmada"
            });

            txtCIReserva.Clear();
            CargarClases();
            CargarAlumnosReservados();
        }

        private void btnGestionarHorarios_Click(object sender, EventArgs e)
        {
            using (var frm = new FormHorarioClase())
            {
                frm.ShowDialog();
            }
            CargarClases();
        }
    }
}