namespace CpGimnasio
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Ribbon1 = new C1.Win.Ribbon.C1Ribbon();
            this.ribbonAppMenu = new C1.Win.Ribbon.RibbonApplicationMenu();
            this.ribbonBottomToolBar1 = new C1.Win.Ribbon.RibbonBottomToolBar();
            this.ribbonConfigToolBar = new C1.Win.Ribbon.RibbonConfigToolBar();
            this.ribbonQat = new C1.Win.Ribbon.RibbonQat();
            this.tabCatalogos = new C1.Win.Ribbon.RibbonTab();
            this.grpCatalogosBase = new C1.Win.Ribbon.RibbonGroup();
            this.btnCaClientes = new C1.Win.Ribbon.RibbonButton();
            this.btnCaMembresias = new C1.Win.Ribbon.RibbonButton();
            this.btnCaServicios = new C1.Win.Ribbon.RibbonButton();
            this.btnCaEntrenadores = new C1.Win.Ribbon.RibbonButton();
            this.grpUsuarios = new C1.Win.Ribbon.RibbonGroup();
            this.btnCaUsuarios = new C1.Win.Ribbon.RibbonButton();
            this.tabOperaciones = new C1.Win.Ribbon.RibbonTab();
            this.grpVentas = new C1.Win.Ribbon.RibbonGroup();
            this.btnOpInscripcion = new C1.Win.Ribbon.RibbonButton();
            this.btnOpAccesos = new C1.Win.Ribbon.RibbonButton();
            this.grpAgenda = new C1.Win.Ribbon.RibbonGroup();
            this.btnOpHorarios = new C1.Win.Ribbon.RibbonButton();
            this.btnOpReservas = new C1.Win.Ribbon.RibbonButton();
            this.tabGerencia = new C1.Win.Ribbon.RibbonTab();
            this.grpReportes = new C1.Win.Ribbon.RibbonGroup();
            this.btnGerenciaReportes = new C1.Win.Ribbon.RibbonButton();
            this.grpSistema = new C1.Win.Ribbon.RibbonGroup();
            this.btnSalir = new C1.Win.Ribbon.RibbonButton();
            this.ribbonTopToolBar1 = new C1.Win.Ribbon.RibbonTopToolBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuarioLogueado = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Ribbon1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Ribbon1
            // 
            this.Ribbon1.ApplicationMenuHolder = this.ribbonAppMenu;
            this.Ribbon1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.Ribbon1.BottomToolBarHolder = this.ribbonBottomToolBar1;
            this.Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar;
            this.Ribbon1.Location = new System.Drawing.Point(0, 0);
            this.Ribbon1.Name = "Ribbon1";
            this.Ribbon1.QatHolder = this.ribbonQat;
            this.Ribbon1.Size = new System.Drawing.Size(800, 161);
            this.Ribbon1.Tabs.Add(this.tabCatalogos);
            this.Ribbon1.Tabs.Add(this.tabOperaciones);
            this.Ribbon1.Tabs.Add(this.tabGerencia);
            this.Ribbon1.TopToolBarHolder = this.ribbonTopToolBar1;
            // 
            // ribbonAppMenu
            // 
            this.ribbonAppMenu.Name = "ribbonAppMenu";
            // 
            // ribbonBottomToolBar1
            // 
            this.ribbonBottomToolBar1.Name = "ribbonBottomToolBar1";
            // 
            // ribbonConfigToolBar
            // 
            this.ribbonConfigToolBar.Name = "ribbonConfigToolBar";
            // 
            // ribbonQat
            // 
            this.ribbonQat.Name = "ribbonQat";
            // 
            // tabCatalogos
            // 
            this.tabCatalogos.Groups.Add(this.grpCatalogosBase);
            this.tabCatalogos.Groups.Add(this.grpUsuarios);
            this.tabCatalogos.Name = "tabCatalogos";
            this.tabCatalogos.Text = "CATÁLOGOS";
            // 
            // grpCatalogosBase
            // 
            this.grpCatalogosBase.Items.Add(this.btnCaClientes);
            this.grpCatalogosBase.Items.Add(this.btnCaMembresias);
            this.grpCatalogosBase.Items.Add(this.btnCaServicios);
            this.grpCatalogosBase.Items.Add(this.btnCaEntrenadores);
            this.grpCatalogosBase.Name = "grpCatalogosBase";
            this.grpCatalogosBase.Text = "Administración de Datos";
            // 
            // btnCaClientes
            // 
            this.btnCaClientes.Name = "btnCaClientes";
            this.btnCaClientes.Text = "Clientes";
            // 
            // btnCaMembresias
            // 
            this.btnCaMembresias.Name = "btnCaMembresias";
            this.btnCaMembresias.Text = "Planes Membresía";
            // 
            // btnCaServicios
            // 
            this.btnCaServicios.Name = "btnCaServicios";
            this.btnCaServicios.Text = "Servicios";
            // 
            // btnCaEntrenadores
            // 
            this.btnCaEntrenadores.Name = "btnCaEntrenadores";
            this.btnCaEntrenadores.Text = "Entrenadores";
            // 
            // grpUsuarios
            // 
            this.grpUsuarios.Items.Add(this.btnCaUsuarios);
            this.grpUsuarios.Name = "grpUsuarios";
            this.grpUsuarios.Text = "Seguridad";
            // 
            // btnCaUsuarios
            // 
            this.btnCaUsuarios.Name = "btnCaUsuarios";
            this.btnCaUsuarios.Text = "Usuarios";
            // 
            // tabOperaciones
            // 
            this.tabOperaciones.Groups.Add(this.grpVentas);
            this.tabOperaciones.Groups.Add(this.grpAgenda);
            this.tabOperaciones.Name = "tabOperaciones";
            this.tabOperaciones.Text = "OPERACIONES";
            // 
            // grpVentas
            // 
            this.grpVentas.Items.Add(this.btnOpInscripcion);
            this.grpVentas.Items.Add(this.btnOpAccesos);
            this.grpVentas.Name = "grpVentas";
            this.grpVentas.Text = "Ventas y Accesos";
            // 
            // btnOpInscripcion
            // 
            this.btnOpInscripcion.Name = "btnOpInscripcion";
            this.btnOpInscripcion.Text = "Punto de Venta";
            // 
            // btnOpAccesos
            // 
            this.btnOpAccesos.Name = "btnOpAccesos";
            this.btnOpAccesos.Text = "Monitor Ingreso";
            // 
            // grpAgenda
            // 
            this.grpAgenda.Items.Add(this.btnOpHorarios);
            this.grpAgenda.Items.Add(this.btnOpReservas);
            this.grpAgenda.Name = "grpAgenda";
            this.grpAgenda.Text = "Agenda Diaria";
            // 
            // btnOpHorarios
            // 
            this.btnOpHorarios.Name = "btnOpHorarios";
            this.btnOpHorarios.Text = "Programar Horarios";
            // 
            // btnOpReservas
            // 
            this.btnOpReservas.Name = "btnOpReservas";
            this.btnOpReservas.Text = "Reservas";
            // 
            // tabGerencia
            // 
            this.tabGerencia.Groups.Add(this.grpReportes);
            this.tabGerencia.Groups.Add(this.grpSistema);
            this.tabGerencia.Name = "tabGerencia";
            this.tabGerencia.Text = "GERENCIA";
            // 
            // grpReportes
            // 
            this.grpReportes.Items.Add(this.btnGerenciaReportes);
            this.grpReportes.Name = "grpReportes";
            this.grpReportes.Text = "Estadísticas";
            // 
            // btnGerenciaReportes
            // 
            this.btnGerenciaReportes.Name = "btnGerenciaReportes";
            this.btnGerenciaReportes.Text = "Reporte Ingresos";
            // 
            // grpSistema
            // 
            this.grpSistema.Items.Add(this.btnSalir);
            this.grpSistema.Name = "grpSistema";
            this.grpSistema.Text = "Sistema";
            // 
            // btnSalir
            // 
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir del Sistema";
            // 
            // ribbonTopToolBar1
            // 
            this.ribbonTopToolBar1.Name = "ribbonTopToolBar1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuarioLogueado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            // 
            // lblUsuarioLogueado
            // 
            this.lblUsuarioLogueado.Name = "lblUsuarioLogueado";
            this.lblUsuarioLogueado.Size = new System.Drawing.Size(68, 17);
            this.lblUsuarioLogueado.Text = "Cargando...";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Ribbon1);
            this.Name = "FrmPrincipal";
            this.Text = "::: Gimnasio Master - Panel de Control :::";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ribbon1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.Ribbon.C1Ribbon Ribbon1;
        private C1.Win.Ribbon.RibbonApplicationMenu ribbonAppMenu;
        private C1.Win.Ribbon.RibbonBottomToolBar ribbonBottomToolBar1;
        private C1.Win.Ribbon.RibbonConfigToolBar ribbonConfigToolBar;
        private C1.Win.Ribbon.RibbonQat ribbonQat;
        private C1.Win.Ribbon.RibbonTab tabCatalogos;
        private C1.Win.Ribbon.RibbonGroup grpCatalogosBase;
        private C1.Win.Ribbon.RibbonButton btnCaClientes;
        private C1.Win.Ribbon.RibbonButton btnCaMembresias;
        private C1.Win.Ribbon.RibbonButton btnCaServicios;
        private C1.Win.Ribbon.RibbonButton btnCaEntrenadores;
        private C1.Win.Ribbon.RibbonGroup grpUsuarios;
        private C1.Win.Ribbon.RibbonButton btnCaUsuarios;
        private C1.Win.Ribbon.RibbonTab tabOperaciones;
        private C1.Win.Ribbon.RibbonGroup grpVentas;
        private C1.Win.Ribbon.RibbonButton btnOpInscripcion;
        private C1.Win.Ribbon.RibbonButton btnOpAccesos;
        private C1.Win.Ribbon.RibbonGroup grpAgenda;
        private C1.Win.Ribbon.RibbonButton btnOpHorarios;
        private C1.Win.Ribbon.RibbonButton btnOpReservas;
        private C1.Win.Ribbon.RibbonTab tabGerencia;
        private C1.Win.Ribbon.RibbonGroup grpReportes;
        private C1.Win.Ribbon.RibbonButton btnGerenciaReportes;
        private C1.Win.Ribbon.RibbonGroup grpSistema;
        private C1.Win.Ribbon.RibbonButton btnSalir;
        private C1.Win.Ribbon.RibbonTopToolBar ribbonTopToolBar1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioLogueado;
    }
}