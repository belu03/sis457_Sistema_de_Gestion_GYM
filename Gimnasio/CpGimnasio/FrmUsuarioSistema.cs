using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using CadGimnasio;
using ClnGimnasio;

namespace CpGimnasio
{
    public partial class FrmUsuarioSistema : Form
    {
        private bool esNuevo = false;

        public FrmUsuarioSistema()
        {
            InitializeComponent();
        }

        private void listar()
        {
            using (var context = new GimnasioEntities())
            {
                var usuarios = context.paUsuarioSistemaListar(txtParametro.Text).ToList();
                dgvLista.DataSource = usuarios;
            }

            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["nombre_usuario"].HeaderText = "Usuario (Login)";
            dgvLista.Columns["rol"].HeaderText = "Rol";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuario Registro";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Registro";

            if (dgvLista.Rows.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["nombre_usuario"];
            btnEditar.Enabled = dgvLista.Rows.Count > 0;
            btnEliminar.Enabled = dgvLista.Rows.Count > 0;
        }

        private void FrmUsuarioSistema_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(1264, 440);
            gbxLista.Location = new Point(20, 110);
            gbxLista.Size = new Size(1224, 240);
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Location = new Point(20, 360);
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbxDatos.Visible = false;

            cbxRol.Items.AddRange(new string[] { "Admin", "Recepcionista" });
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
            txtNombreUsuario.Clear(); txtClave.Clear(); cbxRol.SelectedIndex = -1;
            erpUsuario.Clear(); erpClave.Clear(); erpRol.Clear();
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
            txtNombreUsuario.Focus();
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
            using (var db = new GimnasioEntities())
            {
                var us = db.UsuarioSistema.Find(id);
                txtNombreUsuario.Text = us.nombre_usuario;
                cbxRol.Text = us.rol;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            gbxDatos.Visible = false;
            this.ClientSize = new Size(1264, 440);
            gbxLista.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Enabled = true;
        }

        private string EncriptarClave(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash) sb.Append(b.ToString("X2"));
                return sb.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text)) { erpUsuario.SetError(txtNombreUsuario, "Obligatorio"); return; }
            if (esNuevo && string.IsNullOrWhiteSpace(txtClave.Text)) { erpClave.SetError(txtClave, "Obligatorio"); return; }
            if (string.IsNullOrWhiteSpace(cbxRol.Text)) { erpRol.SetError(cbxRol, "Obligatorio"); return; }

            using (var db = new GimnasioEntities())
            {
                if (esNuevo)
                {
                    string nombreUsuario = txtNombreUsuario.Text.Trim();

                    bool existe = db.UsuarioSistema.Any(x =>
                        x.nombre_usuario == nombreUsuario &&
                        x.estado == 1);

                    if (existe)
                    {
                        MessageBox.Show(
                            "El nombre de usuario ya se encuentra registrado.",
                            "Validación",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        txtNombreUsuario.Focus();
                        return;
                    }
                    string saltStatico = "SaltSeguro2026";
                    var us = new UsuarioSistema
                    {
                        nombre_usuario = txtNombreUsuario.Text.Trim(),
                        contraseña = EncriptarClave(txtClave.Text.Trim(), saltStatico),
                        salt = saltStatico,
                        rol = cbxRol.Text,
                        usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin",
                        fechaRegistro = DateTime.Now,
                        estado = 1
                    };
                    db.UsuarioSistema.Add(us);
                }
                else
                {
                    int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                    var us = db.UsuarioSistema.Find(id);
                    us.nombre_usuario = txtNombreUsuario.Text.Trim();
                    us.rol = cbxRol.Text;
                    if (!string.IsNullOrWhiteSpace(txtClave.Text))
                    {
                        us.contraseña = EncriptarClave(txtClave.Text.Trim(), us.salt);
                    }
                    us.usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin";
                }
                db.SaveChanges();
            }

            listar();
            btnCancelar.PerformClick();
            MessageBox.Show("Usuario guardado", "::: Mensaje :::", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Dar de baja este usuario?", "::: Mensaje :::", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = (int)dgvLista.CurrentRow.Cells["id"].Value;
                using (var db = new GimnasioEntities())
                {
                    var us = db.UsuarioSistema.Find(id);
                    us.estado = -1;
                    us.usuarioRegistro = Util.usuario != null ? Util.usuario.nombre_usuario : "admin";
                    db.SaveChanges();
                }
                listar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}