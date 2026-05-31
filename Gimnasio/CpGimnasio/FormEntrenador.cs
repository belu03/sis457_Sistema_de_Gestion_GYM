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
    public partial class FormEntrenador : Form
    {
        public FormEntrenador()
        {
            InitializeComponent();
        }

        private void FormEntrenador_Load(object sender, EventArgs e)
        {
            dgvLista.DataSource = EntrenadorCln.listar(" ");
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
