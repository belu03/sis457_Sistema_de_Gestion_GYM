using System;
using System.Drawing;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FrmPrincipal : Form
    {
        FrmAutenticacion frmAutenticacion;

        public FrmPrincipal(FrmAutenticacion frmAutenticacion)
        {
            InitializeComponent();
            this.frmAutenticacion = frmAutenticacion;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
           
            // Mostramos quién entró al sistema en la barra inferior
            if (Util.usuario != null)
            {
                lblUsuarioLogueado.Text = $"Usuario conectado: {Util.usuario.nombre_usuario} | Rol: {Util.usuario.rol}";
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Al cerrar el formulario principal, limpiamos la sesión y volvemos al Login
            Util.usuario = null;
            frmAutenticacion.Show();
        }

        // ==========================================
        // EVENTOS DEL RIBBON (CATÁLOGOS)
        // ==========================================
        private void btnCaClientes_Click(object sender, EventArgs e)
        {
            FrmCliente frm = new FrmCliente();
            frm.ShowDialog(this);
        }
        private void btnCaMembresias_Click(object sender, EventArgs e) { new FrmMembresia().ShowDialog(); }
        private void btnCaServicios_Click(object sender, EventArgs e) { new FrmServicio().ShowDialog(); }
        private void btnCaEntrenadores_Click(object sender, EventArgs e) { new FrmEntrenador().ShowDialog(); }
        private void btnCaUsuarios_Click(object sender, EventArgs e) { new FrmUsuarioSistema().ShowDialog(); }

        // ==========================================
        // EVENTOS DEL RIBBON (OPERACIONES)
        // ==========================================
        private void btnOpInscripcion_Click(object sender, EventArgs e) { new FrmInscripcion().ShowDialog(); }
        private void btnOpAccesos_Click(object sender, EventArgs e) { new FrmRegistroAcceso().ShowDialog(); }
        private void btnOpHorarios_Click(object sender, EventArgs e) { new FrmHorarioClase().ShowDialog(); }
        private void btnOpReservas_Click(object sender, EventArgs e) { new FrmReserva().ShowDialog(); }

        // ==========================================
        // EVENTOS DEL RIBBON (GERENCIA / REPORTES)
        // ==========================================
        private void btnGerenciaReportes_Click(object sender, EventArgs e) { new FrmReporte().ShowDialog(); }

        // ==========================================
        // SISTEMA
        // ==========================================
        private void btnSalir_Click(object sender, EventArgs e) { Close(); }
    }
}