using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClnGimnasio;

namespace CpGimnasio
{
    public partial class FrmReporte : Form
    {
        public FrmReporte()
        {
            InitializeComponent();
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            Size = new Size(1280, 720); // Pantalla completa para leer datos financieros
            dtpInicio.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFin.Value = DateTime.Now;
            EstilosUI.FormatearGrillaReporte(dgvReporte);
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (dtpInicio.Value.Date > dtpFin.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var lista = ReporteCln.ReporteIngresos(dtpInicio.Value, dtpFin.Value);
            dgvReporte.DataSource = lista;

            dgvReporte.Columns["id"].Visible = false;
            dgvReporte.Columns["ci"].HeaderText = "CI Cliente";
            dgvReporte.Columns["cliente"].HeaderText = "Cliente";
            dgvReporte.Columns["plan_membresia"].HeaderText = "Plan Adquirido";
            dgvReporte.Columns["fecha_transaccion"].HeaderText = "Fecha Cobro";
            dgvReporte.Columns["monto_pagado"].HeaderText = "Monto (Bs)";
            dgvReporte.Columns["metodo_pago"].HeaderText = "Método";

            decimal total = lista.Sum(x => x.monto_pagado);
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}