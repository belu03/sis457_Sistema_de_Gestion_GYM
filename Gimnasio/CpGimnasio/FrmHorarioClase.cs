using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CadGimnasio;
using ClnGimnasio;

namespace CpGimnasio
{
    public partial class FrmHorarioClase : Form
    {
        private bool esNuevo = false;

        public FrmHorarioClase()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = HorarioClaseCln.listarPa(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["id_servicio"].Visible = false;
            dgvLista.Columns["id_entrenador"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;

            dgvLista.Columns["servicio"].HeaderText = "Servicio/Clase";
            dgvLista.Columns["entrenador"].HeaderText = "Entrenador";
            dgvLista.Columns["dia_semana"].HeaderText = "Día";
            dgvLista.Columns["hora_inicio"].HeaderText = "Hora Inicio";
            dgvLista.Columns["hora_fin"].HeaderText = "Hora Fin";
            dgvLista.Columns["cupos_reservados"].HeaderText = "Cupos Reservados";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["dia_semana"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }

        private void cargarCombos()
        {
            cbxServicio.DataSource = ServicioCln.listar();
            cbxServicio.DisplayMember = "nombre";
            cbxServicio.ValueMember = "id";
            cbxServicio.SelectedIndex = -1;

            var entrenadores = EntrenadorCln.listar().Select(e => new { e.id, nombreCompleto = $"{e.nombre} {e.apellido}" }).ToList();
            cbxEntrenador.DataSource = entrenadores;
            cbxEntrenador.DisplayMember = "nombreCompleto";
            cbxEntrenador.ValueMember = "id";
            cbxEntrenador.SelectedIndex = -1;

            cbxDia.Items.Clear();
            cbxDia.Items.AddRange(new string[] { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo" });
        }

        private void FrmHorarioClase_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1264, 440);
            gbxLista.Location = new Point(20, 110);
            gbxLista.Size = new Size(1224, 240);
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Location = new Point(20, 360);
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxDatos.Visible = false;

            listar();
            cargarCombos();
            EstilosUI.FormatearGrilla(dgvLista);
        }

        private void btnBuscar_Click(object sender, EventArgs e) => listar();

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        // --- CORRECCIÓN: Método limpiar() restaurado ---
        private void limpiar()
        {
            cbxServicio.SelectedIndex = -1;
            cbxEntrenador.SelectedIndex = -1;
            cbxDia.SelectedIndex = -1;
            txtHoraInicio.Clear();
            txtHoraFin.Clear();
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
            limpiar();

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var horario = HorarioClaseCln.obtenerUno(id);
            cbxServicio.SelectedValue = horario.id_servicio;
            cbxEntrenador.SelectedValue = horario.id_entrenador;
            cbxDia.Text = horario.dia_semana;
            txtHoraInicio.Text = horario.hora_inicio.ToString(@"hh\:mm");
            txtHoraFin.Text = horario.hora_fin.ToString(@"hh\:mm");
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
            if (cbxServicio.SelectedValue == null || cbxEntrenador.SelectedValue == null || string.IsNullOrWhiteSpace(cbxDia.Text))
            {
                MessageBox.Show("Servicio, Entrenador y Día son obligatorios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var horario = new HorarioClase()
            {
                id_servicio = (int)cbxServicio.SelectedValue,
                id_entrenador = (int)cbxEntrenador.SelectedValue,
                dia_semana = cbxDia.Text,
                hora_inicio = TimeSpan.Parse(txtHoraInicio.Text.Trim()),
                hora_fin = TimeSpan.Parse(txtHoraFin.Text.Trim()),
                usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin"
            };

            if (esNuevo)
            {
                horario.fechaRegistro = DateTime.Now;
                horario.estado = 1;
                horario.cupos_reservados = 0;
                HorarioClaseCln.crear(horario);
            }
            else
            {
                horario.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                HorarioClaseCln.modificar(horario);
            }

            listar();
            btnCancelar.PerformClick();
            MessageBox.Show("Horario guardado correctamente.", "::: Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null) return;
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            if (MessageBox.Show("¿Eliminar este horario de clase de forma permanente?", "::: Mensaje :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HorarioClaseCln.eliminar(id, Util.usuario != null ? Util.usuario.nombre_usuario : "admin");
                listar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}