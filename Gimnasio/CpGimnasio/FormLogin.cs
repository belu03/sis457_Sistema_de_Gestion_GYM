using ClnGimnasio;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.gym_login;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            pbLogo.Image = Properties.Resources.gym_logo_2;
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;

            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.BackColor = Color.FromArgb(37, 99, 235);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.Image = null;

            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.BackColor = Color.FromArgb(225, 29, 72);
            btnSalir.ForeColor = Color.White;
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Image = null;

            SetLabelsTransparent();
        }

        private void SetLabelsTransparent()
        {
            foreach (Control c in this.Controls)
                if (c is Label) c.BackColor = Color.Transparent;
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Ingrese usuario y contraseña", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var usuarioValido = AuthCln.ValidarLogin(txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
            if (usuarioValido != null)
            {
                new FormPrincipal(usuarioValido.nombre_usuario, usuarioValido.rol).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtContraseña.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
    }
}