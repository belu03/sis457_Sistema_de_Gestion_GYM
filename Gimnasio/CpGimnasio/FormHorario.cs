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
    public partial class FormHorario : Form
    {
        public FormHorario()
        {
            InitializeComponent();
        }

        private void FormHorario_Load(object sender, EventArgs e)
        {
            dgvLista.DataSource = HorarioCln.listar(" ");
        }
    }
}
