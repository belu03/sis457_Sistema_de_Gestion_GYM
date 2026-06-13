using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadGimnasio;
using ClnGimnasio;

namespace CpGimnasio
{
    public partial class FrmRegistroAcceso : Form
    {
        public FrmRegistroAcceso()
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = RegistroAccesoCln.listarPa(txtParametro.Text);
            dgvLista.DataSource = lista;

            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;

            dgvLista.Columns["ci"].HeaderText = "CI Cliente";
            dgvLista.Columns["nombre"].HeaderText = "Nombres";
            dgvLista.Columns["apellido"].HeaderText = "Apellidos";
            dgvLista.Columns["fecha_hora"].HeaderText = "Hora de Ingreso";
            dgvLista.Columns["fecha_hora"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dgvLista.Columns["tipo"].HeaderText = "Movimiento";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Recepcionista";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha Sistema";
        }

        private void FrmRegistroAcceso_Load(object sender, EventArgs e)
        {
            Size = new Size(1280, 720); // Monitor siempre en pantalla completa
            listar();
            EstilosUI.FormatearGrilla(dgvLista);
        }

        private void btnBuscar_Click(object sender, EventArgs e) => listar();

        private void txtParametro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}