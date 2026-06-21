using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CadGimnasio;
using ClnGimnasio;

namespace CpGimnasio
{
    public partial class FrmReserva : Form
    {
        private bool esNuevo = false;

        public FrmReserva()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ReservaCln.listarPa(txtParametro.Text);

            // Filtramos la lista para borrar de la pantalla las reservas anuladas o dadas de baja
            var listaActivas = lista.Where(r => r.estado != -1 && r.estado_reserva != "Anulada").ToList();

            dgvLista.DataSource = listaActivas;

            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["id_cliente"].Visible = false;
            dgvLista.Columns["id_horarioclase"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;

            dgvLista.Columns["ci"].HeaderText = "CI Cliente";
            dgvLista.Columns["cliente"].HeaderText = "Alumno";
            dgvLista.Columns["clase"].HeaderText = "Clase";
            dgvLista.Columns["fecha_reserva"].HeaderText = "Fecha";
            dgvLista.Columns["asistio"].HeaderText = "Asistió";
            dgvLista.Columns["estado_reserva"].HeaderText = "Estado Operativo";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            if (listaActivas.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["cliente"];
            btnEditar.Enabled = listaActivas.Count > 0;
            btnEliminar.Enabled = listaActivas.Count > 0;
        }

        private void cargarCombos()
        {
            var clientes = ClienteCln.listar().Select(c => new { c.id, nombreCompleto = $"{c.nombre} {c.apellido} ({c.ci})" }).ToList();
            cbxCliente.DataSource = clientes;
            cbxCliente.DisplayMember = "nombreCompleto";
            cbxCliente.ValueMember = "id";
            cbxCliente.SelectedIndex = -1;

            var horarios = HorarioClaseCln.listar().Where(h => {
                var serv = ServicioCln.obtenerUno(h.id_servicio);
                return h.cupos_reservados < serv.capacidad_maxima; // FILTRO: Solo muestra si hay cupos
            }).Select(h => {
                var serv = ServicioCln.obtenerUno(h.id_servicio);
                int disponibles = serv.capacidad_maxima - h.cupos_reservados;
                return new { h.id, descripcion = $"{serv.nombre} - {h.dia_semana} {h.hora_inicio.ToString(@"hh\:mm")} (Quedan {disponibles} cupos)" };
            }).ToList();

            cbxHorario.DataSource = horarios;
            cbxHorario.DisplayMember = "descripcion";
            cbxHorario.ValueMember = "id";
            cbxHorario.SelectedIndex = -1;

            cbxEstado.Items.Clear();
            cbxEstado.Items.AddRange(new string[] { "Confirmada", "Pendiente" });
        }

        private void FrmReserva_Load(object sender, EventArgs e)
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

        private void limpiar()
        {
            cbxCliente.SelectedIndex = -1; cbxHorario.SelectedIndex = -1; cbxEstado.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now; chkAsistio.Checked = false;
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

            // Habilitar selección de cliente y clase para nuevas reservas
            cbxCliente.Enabled = true;
            cbxHorario.Enabled = true;

            cargarCombos();
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

            // BLOQUEO DE SEGURIDAD: Evita alterar los cupos cruzados al editar
            cbxCliente.Enabled = false;
            cbxHorario.Enabled = false;

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var reserva = ReservaCln.obtenerUno(id);
            cbxCliente.SelectedValue = reserva.id_cliente;
            cbxHorario.SelectedValue = reserva.id_horarioclase;
            dtpFecha.Value = reserva.fecha_reserva;
            chkAsistio.Checked = reserva.asistio;
            cbxEstado.Text = reserva.estado_reserva;
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
            if (cbxCliente.SelectedValue == null || cbxHorario.SelectedValue == null)
            {
                MessageBox.Show("Cliente y Horario son obligatorios", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validación adicional: La fecha de la reserva no puede ser anterior a la fecha actual para nuevas reservas
            if (esNuevo && dtpFecha.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("La fecha de la reserva no puede ser anterior a hoy.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFecha.Focus();
                return;
            }

            using (var db = new GimnasioEntities())
            {
                if (esNuevo)
                {
                    int idHorario = (int)cbxHorario.SelectedValue;
                    var horarioDB = db.HorarioClase.Find(idHorario);
                    var servicioDB = db.Servicio.Find(horarioDB.id_servicio);

                    // Doble check de seguridad por si dos personas reservan al mismo tiempo
                    if (horarioDB.cupos_reservados >= servicioDB.capacidad_maxima)
                    {
                        MessageBox.Show("Esta clase ya se ha llenado. Por favor, elija otro horario.", "Cupo Lleno", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var reserva = new Reserva()
                    {
                        id_cliente = (int)cbxCliente.SelectedValue,
                        id_horarioclase = idHorario,
                        fecha_reserva = dtpFecha.Value.Date,
                        asistio = chkAsistio.Checked,
                        estado_reserva = string.IsNullOrWhiteSpace(cbxEstado.Text) ? "Confirmada" : cbxEstado.Text,
                        usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin",
                        fechaRegistro = DateTime.Now,
                        estado = 1
                    };
                    db.Reserva.Add(reserva);

                    // LÓGICA CRÍTICA: Descontamos el cupo sumando 1 a los reservados
                    horarioDB.cupos_reservados++;
                }
                else
                {
                    int idReserva = (int)dgvLista.CurrentRow.Cells["id"].Value;
                    var reservaDB = db.Reserva.Find(idReserva);

                    reservaDB.asistio = chkAsistio.Checked;
                    reservaDB.estado_reserva = cbxEstado.Text;
                    reservaDB.usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin";
                }

                db.SaveChanges();
            }

            listar();
            btnCancelar.PerformClick();
            MessageBox.Show("Reserva procesada exitosamente.", "::: Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null) return;
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;

            if (MessageBox.Show("¿Anular reserva y liberar el cupo de la clase?", "::: Mensaje :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (var db = new GimnasioEntities())
                {
                    var reservaDB = db.Reserva.Find(id);
                    if (reservaDB != null && reservaDB.estado != -1)
                    {
                        // Anulamos la reserva
                        reservaDB.estado = -1;
                        reservaDB.estado_reserva = "Anulada";
                        reservaDB.usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin";

                        // LÓGICA CRÍTICA: Liberamos el cupo restando 1
                        var horarioDB = db.HorarioClase.Find(reservaDB.id_horarioclase);
                        if (horarioDB != null && horarioDB.cupos_reservados > 0)
                        {
                            horarioDB.cupos_reservados--;
                        }

                        db.SaveChanges();
                    }
                }

                listar();
                MessageBox.Show("Reserva anulada. El cupo ha sido liberado.", "::: Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}