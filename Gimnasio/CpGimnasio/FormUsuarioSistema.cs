using CadGimnasio;
using ClnGimnasio;
using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormUsuarioSistema : Form
    {
        private bool esNuevo = false;
        private int idSeleccionado = 0;

        public FormUsuarioSistema()
        {
            InitializeComponent();
        }

        private void FormUsuarioSistema_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.gym_fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.White;
            SetLabelsTransparent();
            pbLogo.Image = Properties.Resources.USUARIOS;
            AplicarEstilosVisuales();
            CargarCombos();
            ListarUsuarios();
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
            cmbRol.Items.AddRange(new string[] { "Admin", "Recepcionista" });
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void ListarUsuarios(string filtro = "")
        {
            var lista = Repositorio<UsuarioSistema>.Listar().Where(u => u.activo == true).ToList();
            if (!string.IsNullOrEmpty(filtro))
                lista = lista.Where(u => u.nombre_usuario.Contains(filtro)).ToList();

            dgvLista.DataSource = lista;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvLista.Columns["id"] != null) dgvLista.Columns["id"].Visible = false;
            if (dgvLista.Columns["contraseña"] != null) dgvLista.Columns["contraseña"].Visible = false;
            if (dgvLista.Columns["salt"] != null) dgvLista.Columns["salt"].Visible = false;
            if (dgvLista.Columns["activo"] != null) dgvLista.Columns["activo"].Visible = false;
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
            txtUsuario.Focus();
        }

        // ========== MÉTODOS DE ENCRIPTACIÓN ==========
        private string GenerarSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private string GenerarHash(string password, string salt)
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
            if (!ValidarCampos()) return;

            if (esNuevo)
            {
                // Nuevo: generar salt aleatorio
                string saltAleatorio = GenerarSalt();
                string hashPassword = GenerarHash(txtContraseña.Text.Trim(), saltAleatorio);

                var us = new UsuarioSistema
                {
                    nombre_usuario = txtUsuario.Text.Trim(),
                    contraseña = hashPassword,
                    salt = saltAleatorio,
                    rol = cmbRol.Text,
                    activo = true
                };
                Repositorio<UsuarioSistema>.Crear(us);
            }
            else
            {
                var us = Repositorio<UsuarioSistema>.ObtenerUno(idSeleccionado);
                us.nombre_usuario = txtUsuario.Text.Trim();

                // Solo se actualiza la contraseña si se escribió una nueva
                if (!string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    // Usar el salt existente (no se cambia)
                    string hashPassword = GenerarHash(txtContraseña.Text.Trim(), us.salt);
                    us.contraseña = hashPassword;
                }

                us.rol = cmbRol.Text;
                Repositorio<UsuarioSistema>.Modificar(us);
            }

            ListarUsuarios();
            CancelarOperacion();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0) return;
            esNuevo = false;
            var u_db = Repositorio<UsuarioSistema>.ObtenerUno(idSeleccionado);
            txtUsuario.Text = u_db.nombre_usuario;
            txtContraseña.Clear();   // se deja vacío; si se escribe algo se actualizará
            cmbRol.Text = u_db.rol;
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
            if (MessageBox.Show("¿Eliminar este usuario del sistema?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var u_db = Repositorio<UsuarioSistema>.ObtenerUno(idSeleccionado);
                u_db.activo = false;
                Repositorio<UsuarioSistema>.Modificar(u_db);
                ListarUsuarios();
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
            txtUsuario.Clear();
            txtContraseña.Clear();
            cmbRol.SelectedIndex = -1;
            erpUS.Clear();
        }

        private void HabilitarCampos(bool habilitar)
        {
            txtUsuario.Enabled = habilitar;
            txtContraseña.Enabled = habilitar;
            cmbRol.Enabled = habilitar;
        }

        private bool ValidarCampos()
        {
            bool ok = true;
            erpUS.Clear();
            if (string.IsNullOrWhiteSpace(txtUsuario.Text)) { erpUS.SetError(txtUsuario, "Requerido"); ok = false; }
            if (esNuevo && string.IsNullOrWhiteSpace(txtContraseña.Text)) { erpUS.SetError(txtContraseña, "Requerido al crear"); ok = false; }
            if (string.IsNullOrWhiteSpace(cmbRol.Text)) { erpUS.SetError(cmbRol, "Requerido"); ok = false; }
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

        private void txtBuscar_TextChanged(object sender, EventArgs e) => ListarUsuarios(txtBuscar.Text.Trim());
    }
}