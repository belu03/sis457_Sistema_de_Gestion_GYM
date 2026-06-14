using ClnGimnasio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormAsistencia : Form
    {
        public FormAsistencia()
        {
            InitializeComponent();
        }

        private void FormAsistencia_Load(object sender, EventArgs e)
        {
            dgvLista.DataSource = AsistenciaCln.listar(" ");
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            new FormServicio().Show();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            new FormUsuario().Show();
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            new FormHorario().Show();
        }

        private void btnMembresia_Click(object sender, EventArgs e)
        {
            new FormMembresia().Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
