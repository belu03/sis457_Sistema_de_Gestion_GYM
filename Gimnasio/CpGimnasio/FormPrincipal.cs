using System;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void PrincipalForm_Load(object sender, EventArgs e)
        {
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            new FormUsuario().Show();
        }

        private void btnEntrenador_Click(object sender, EventArgs e)
        {
            new FormEntrenador().Show();
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            new FormServicio().Show();
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            new FormHorario().Show();
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            new FormReserva().Show();
        }

        private void btnMembresia_Click(object sender, EventArgs e)
        {
            new FormMembresia().Show();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            new FormPago().Show();
        }

        private void btnAsistencia_Click(object sender, EventArgs e)
        {
            new FormAsistencia().Show();
        }
    }
}