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
    public partial class FormReserva : Form
    {
        public FormReserva()
        {
            InitializeComponent();
        }

        private void FormReserva_Load(object sender, EventArgs e)
        {
            dgvLista.DataSource = ReservaCln.listar(" ");
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            new FormUsuario().Show();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void cboFecha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
