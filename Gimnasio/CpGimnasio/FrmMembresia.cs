using CadGimnasio;
using ClnGimnasio;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FrmMembresia : Form
    {
        private bool esNuevo = false;

        public FrmMembresia()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = MembresiaCln.listarPa(txtParametro.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["tipo"].HeaderText = "Tipo de Plan";
            dgvLista.Columns["precio"].HeaderText = "Precio (Bs)";
            dgvLista.Columns["duracion_dias"].HeaderText = "Duración (Días)";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["tipo"];
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
        }

        private void FrmMembresia_Load(object sender, EventArgs e)
        {
            // 1. Configuramos el tamaño compacto del formulario
            this.ClientSize = new Size(1264, 440);

            // 2. Ajustamos la lista para que SIEMPRE se vea
            gbxLista.Location = new Point(20, 110);
            gbxLista.Size = new Size(1224, 240);
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // 3. Fijamos los botones debajo de la lista
            pnlAcciones.Location = new Point(20, 360);
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            // 4. Ocultamos el panel de edición
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
            txtTipo.Clear(); nudPrecio.Value = 0; nudDuracion.Value = 0;
            erpTipo.Clear(); erpPrecio.Clear(); erpDuracion.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.ClientSize = new Size(1264, 680);
            gbxDatos.Location = new Point(20, 430);
            gbxDatos.Size = new Size(1224, 210); // Alto estándar del panel
            gbxDatos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxDatos.Visible = true;
            gbxDatos.BringToFront();
            esNuevo = true;
            pnlAcciones.Enabled = false;
            limpiar();
            txtTipo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLista.CurrentRow == null) return;
            esNuevo = false;
            pnlAcciones.Enabled = false;

            // 1. Quitamos los anclajes inferiores temporalmente
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // 2. Expandimos la ventana
            this.ClientSize = new Size(1264, 680);

            // 3. Posicionamos el panel de datos EXACTAMENTE debajo de los botones
            gbxDatos.Location = new Point(20, 430);
            gbxDatos.Size = new Size(1224, 210); // Alto estándar del panel
            gbxDatos.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxDatos.Visible = true;
            gbxDatos.BringToFront();

            erpTipo.Clear(); erpPrecio.Clear(); erpDuracion.Clear();

            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            var membresia = MembresiaCln.obtenerUno(id);
            txtTipo.Text = membresia.tipo;
            nudPrecio.Value = membresia.precio;
            nudDuracion.Value = membresia.duracion_dias;
            txtTipo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // 1. Ocultamos el panel de edición
            gbxDatos.Visible = false;

            // 2. Volvemos a encoger la ventana a su tamaño compacto
            this.ClientSize = new Size(1264, 440);

            // 3. Restauramos los anclajes para que la lista vuelva a ser responsiva
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            pnlAcciones.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            erpTipo.Clear();
            erpPrecio.Clear();
            erpDuracion.Clear();

            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            {
                erpTipo.SetError(txtTipo, "Obligatorio");
                txtTipo.Focus();
                return;
            }

            if (nudPrecio.Value <= 0)
            {
                erpPrecio.SetError(nudPrecio, "Mayor a 0");
                nudPrecio.Focus();
                return;
            }

            if (nudDuracion.Value <= 0)
            {
                erpDuracion.SetError(nudDuracion, "Mayor a 0");
                nudDuracion.Focus();
                return;
            }

            if (esNuevo)
            {
                var lista = MembresiaCln.listarPa("");

                var membresiaExistente = lista.FirstOrDefault(x =>
                    x.tipo.Trim().ToUpper() ==
                    txtTipo.Text.Trim().ToUpper());

                if (membresiaExistente != null)
                {
                    MessageBox.Show(
                        $"La membresía '{membresiaExistente.tipo}' ya se encuentra registrada con un precio de Bs. {membresiaExistente.precio:N2} y una duración de {membresiaExistente.duracion_dias} días.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtTipo.Focus();
                    return;
                }
            }

            var membresia = new Membresia()
            {
                tipo = txtTipo.Text.Trim(),
                precio = nudPrecio.Value,
                duracion_dias = (int)nudDuracion.Value,
                usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin"
            };

            if (esNuevo)
            {
                membresia.fechaRegistro = DateTime.Now;
                membresia.estado = 1;
                MembresiaCln.crear(membresia);
            }
            else
            {
                membresia.id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                MembresiaCln.modificar(membresia);
            }

            listar();
            btnCancelar.PerformClick();

            MessageBox.Show(
                "Membresía guardada",
                "::: Mensaje :::",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
            string tipo = dgvLista.CurrentRow.Cells["tipo"].Value.ToString();
            if (MessageBox.Show($"¿Eliminar {tipo}?", "::: Mensaje :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MembresiaCln.eliminar(id, Util.usuario != null ? Util.usuario.nombre_usuario : "admin");
                listar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}