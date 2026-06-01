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
    public partial class FormPago : Form
    {
        public FormPago()
        {
            InitializeComponent();
        }

        private void FormPago_Load(object sender, EventArgs e)
        {
            dgvLista.DataSource = PagoCln.listar(" ");
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            new FormUsuario().Show();
        }
    }
}
