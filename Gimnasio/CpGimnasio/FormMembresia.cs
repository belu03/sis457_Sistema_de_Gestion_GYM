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
    public partial class FormMembresia : Form
    {
        public FormMembresia()
        {
            InitializeComponent();
        }

        private void FormMembresia_Load(object sender, EventArgs e)
        {
            dgvLista.DataSource = MembresiaCln.listar(" ");
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            new FormUsuario().Show();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            new FormPago().Show();
        }
    }
}
