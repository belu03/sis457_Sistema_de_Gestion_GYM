using System;
using System.Drawing;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormPrincipal : Form
    {
        private string nombreUsuario, rolUsuario;
        private Form formularioActivo;

        public FormPrincipal(string nombre, string rol)
        {
            InitializeComponent();
            nombreUsuario = nombre;
            rolUsuario = rol;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Properties.Resources.gym_fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.White;
            SetLabelsTransparent();
            lblInfoUsuario.Text = $"Usuario: {nombreUsuario} | Rol: {rolUsuario}";
            pbLogo.Image = Properties.Resources.gym_logo_2;

            ConfigurarBotonMenu(btnRecepcion, "Recepción / Ventas");
            ConfigurarBotonMenu(btnAgenda, "Agenda Diaria");
            ConfigurarBotonMenu(btnAccesos, "Monitor de Accesos");
            ConfigurarBotonMenu(btnEntrenadores, "Entrenadores");
            ConfigurarBotonMenu(btnServicios, "Servicios / Clases");
            ConfigurarBotonMenu(btnMembresias, "Planes Membresía");
            ConfigurarBotonMenu(btnUsuariosSistema, "Usuarios Sistema");
        }

        private void ConfigurarBotonMenu(Button btn, string texto)
        {
            btn.Text = "  " + texto;
            btn.Image = null;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = Color.White;
            btn.BackColor = Color.Transparent;
            btn.Font = new Font("Segoe UI", 10F);
            btn.Cursor = Cursors.Hand;
            btn.Height = 50;
        }

        private void AbrirFormularioHijo(Form formHijo)
        {
            formularioActivo?.Close();
            formularioActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(formHijo);
            pnlContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
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

        private void btnRecepcion_Click(object sender, EventArgs e) => AbrirFormularioHijo(new FormInscripcion());
        private void btnAgenda_Click(object sender, EventArgs e) => AbrirFormularioHijo(new FormAgenda());
        private void btnAccesos_Click(object sender, EventArgs e) => AbrirFormularioHijo(new FormRegistroAcceso());
        private void btnEntrenadores_Click(object sender, EventArgs e) => AbrirFormularioHijo(new FormEntrenador());
        private void btnServicios_Click(object sender, EventArgs e) => AbrirFormularioHijo(new FormServicio());
        private void btnMembresias_Click(object sender, EventArgs e) => AbrirFormularioHijo(new FormMembresia());
        private void btnUsuariosSistema_Click(object sender, EventArgs e) => AbrirFormularioHijo(new FormUsuarioSistema());
        private void btnHorarios_Click(object sender, EventArgs e) => AbrirFormularioHijo(new FormHorarioClase());

        private void FormPrincipal_FormClosed(object sender, FormClosedEventArgs e) => Application.Exit();
    }
}