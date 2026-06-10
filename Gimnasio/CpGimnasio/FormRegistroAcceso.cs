using CadGimnasio;
using ClnGimnasio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormRegistroAcceso : Form
    {
        // Datos base en memoria
        private List<Cliente> clientes;
        private List<Inscripcion> inscripcionesActivas;
        private List<Membresia> membresias;

        public FormRegistroAcceso()
        {
            InitializeComponent();
        }

        private void FormRegistroAcceso_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.gym_fondo;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackColor = Color.White;
            SetLabelsTransparent();
            pbLogo.Image = Properties.Resources.ASISTENCIA;
            ConfigurarEstilos();

            // Cargar datos base una sola vez
            clientes = Repositorio<Cliente>.Listar();
            inscripcionesActivas = Repositorio<Inscripcion>.Listar().Where(i => i.estado == "Activa").ToList();
            membresias = Repositorio<Membresia>.Listar();

            ListarAccesos();
        }

        private void SetLabelsTransparent()
        {
            foreach (Control c in this.Controls)
                if (c is Label) c.BackColor = Color.Transparent;
        }

        private void ConfigurarEstilos()
        {
            dgvLista.BackgroundColor = Color.White;
            dgvLista.BorderStyle = BorderStyle.None;
            dgvLista.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLista.RowHeadersVisible = false;
            dgvLista.EnableHeadersVisualStyles = false;
            dgvLista.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(31, 41, 55);
            dgvLista.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLista.ColumnHeadersHeight = 35;
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLista.ReadOnly = true;

            btnActualizar.BackColor = Color.FromArgb(37, 99, 235);
            btnActualizar.ForeColor = Color.White;
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.FlatAppearance.BorderSize = 0;
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Image = null;
        }

        private void ListarAccesos(string filtro = "")
        {
            // Solo consultamos accesos (datos cambiantes)
            var accesos = Repositorio<RegistroAcceso>.Listar().Where(r => r.tipo == "Entrada");

            var lista = accesos.Select(r => {
                var cli = clientes.FirstOrDefault(c => c.id == r.id_cliente);
                var ins = inscripcionesActivas.FirstOrDefault(i => i.id_cliente == r.id_cliente && i.fecha_fin >= r.fecha_hora.Date);
                string plan = "Sin Plan Activo";
                if (ins != null)
                {
                    var mem = membresias.FirstOrDefault(m => m.id == ins.id_membresia);
                    if (mem != null) plan = mem.tipo;
                }
                return new
                {
                    r.id,
                    Carnet_CI = cli?.ci,
                    Cliente = cli?.nombre + " " + cli?.apellido,
                    Fecha = r.fecha_hora.ToString("dd/MM/yyyy"),
                    Hora_Llegada = r.fecha_hora.ToString("HH:mm"),
                    Plan_Actual = plan
                };
            }).OrderByDescending(x => x.id).ToList();

            if (!string.IsNullOrEmpty(filtro))
            {
                lista = lista.Where(x => x.Cliente.ToLower().Contains(filtro.ToLower()) ||
                                         x.Carnet_CI.Contains(filtro)).ToList();
            }

            dgvLista.DataSource = lista;
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgvLista.Columns["id"] != null) dgvLista.Columns["id"].Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e) => ListarAccesos(txtBuscar.Text.Trim());
        private void btnActualizar_Click(object sender, EventArgs e) => ListarAccesos(txtBuscar.Text.Trim());
    }
}