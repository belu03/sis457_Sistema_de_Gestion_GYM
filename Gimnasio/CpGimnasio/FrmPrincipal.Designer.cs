namespace CpGimnasio
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
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
            this.Ribbon1.AccessibleRole = System.Windows.Forms.AccessibleRole.Row;
            this.Ribbon1.ApplicationMenuHolder = this.ribbonAppMenu;
            this.Ribbon1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.Ribbon1.BottomToolBarHolder = this.ribbonBottomToolBar1;
            this.Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar;
            this.Ribbon1.Font = new System.Drawing.Font("HP Simplified", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ribbon1.Location = new System.Drawing.Point(0, 0);
            this.Ribbon1.Name = "Ribbon1";
            this.Ribbon1.QatHolder = this.ribbonQat;
            this.Ribbon1.Size = new System.Drawing.Size(1200, 201);
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
            this.btnCaClientes.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnCaClientes.IconSet")))));
            this.btnCaClientes.Name = "btnCaClientes";
            this.btnCaClientes.Text = "Clientes";
            this.btnCaClientes.Click += new System.EventHandler(this.btnCaClientes_Click);
            // 
            // btnCaMembresias
            // 
            this.btnCaMembresias.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnCaMembresias.IconSet")))));
            this.btnCaMembresias.Name = "btnCaMembresias";
            this.btnCaMembresias.Text = "Planes Membresía";
            this.btnCaMembresias.Click += new System.EventHandler(this.btnCaMembresias_Click);
            // 
            // btnCaServicios
            // 
            this.btnCaServicios.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnCaServicios.IconSet")))));
            this.btnCaServicios.Name = "btnCaServicios";
            this.btnCaServicios.Text = "Servicios";
            this.btnCaServicios.Click += new System.EventHandler(this.btnCaServicios_Click);
            // 
            // btnCaEntrenadores
            // 
            this.btnCaEntrenadores.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnCaEntrenadores.IconSet")))));
            this.btnCaEntrenadores.Name = "btnCaEntrenadores";
            this.btnCaEntrenadores.Text = "Entrenadores";
            this.btnCaEntrenadores.Click += new System.EventHandler(this.btnCaEntrenadores_Click);
            // 
            // grpUsuarios
            // 
            this.grpUsuarios.Items.Add(this.btnCaUsuarios);
            this.grpUsuarios.Name = "grpUsuarios";
            this.grpUsuarios.Text = "Seguridad";
            // 
            // btnCaUsuarios
            // 
            this.btnCaUsuarios.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnCaUsuarios.IconSet")))));
            this.btnCaUsuarios.Name = "btnCaUsuarios";
            this.btnCaUsuarios.Text = "Usuarios";
            this.btnCaUsuarios.Click += new System.EventHandler(this.btnCaUsuarios_Click);
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
            this.btnOpInscripcion.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnOpInscripcion.IconSet")))));
            this.btnOpInscripcion.Name = "btnOpInscripcion";
            this.btnOpInscripcion.Text = "Punto de Venta";
            this.btnOpInscripcion.Click += new System.EventHandler(this.btnOpInscripcion_Click);
            // 
            // btnOpAccesos
            // 
            this.btnOpAccesos.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnOpAccesos.IconSet")))));
            this.btnOpAccesos.Name = "btnOpAccesos";
            this.btnOpAccesos.Text = "Monitor Ingreso";
            this.btnOpAccesos.Click += new System.EventHandler(this.btnOpAccesos_Click);
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
            this.btnOpHorarios.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnOpHorarios.IconSet")))));
            this.btnOpHorarios.Name = "btnOpHorarios";
            this.btnOpHorarios.Text = "Programar Horarios";
            this.btnOpHorarios.Click += new System.EventHandler(this.btnOpHorarios_Click);
            // 
            // btnOpReservas
            // 
            this.btnOpReservas.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnOpReservas.IconSet")))));
            this.btnOpReservas.Name = "btnOpReservas";
            this.btnOpReservas.Text = "Reservas";
            this.btnOpReservas.Click += new System.EventHandler(this.btnOpReservas_Click);
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
            this.btnGerenciaReportes.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnGerenciaReportes.IconSet")))));
            this.btnGerenciaReportes.Name = "btnGerenciaReportes";
            this.btnGerenciaReportes.Text = "Reporte Ingresos";
            this.btnGerenciaReportes.Click += new System.EventHandler(this.btnGerenciaReportes_Click);
            // 
            // grpSistema
            // 
            this.grpSistema.Items.Add(this.btnSalir);
            this.grpSistema.Name = "grpSistema";
            this.grpSistema.Text = "Sistema";
            // 
            // btnSalir
            // 
            this.btnSalir.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(64, 64), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnSalir.IconSet")))));
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Text = "Salir del Sistema";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 26);
            this.statusStrip1.TabIndex = 0;
            // 
            // lblUsuarioLogueado
            // 
            this.lblUsuarioLogueado.Name = "lblUsuarioLogueado";
            this.lblUsuarioLogueado.Size = new System.Drawing.Size(83, 20);
            this.lblUsuarioLogueado.Text = "Cargando...";
            // 
            // FrmPrincipal
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::CpGimnasio.Properties.Resources.fondo4_jpg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "::: Gimnasio La Plata - Panel de Control :::";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Ribbon1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private C1.Win.Ribbon.C1Ribbon Ribbon1;
        private C1.Win.Ribbon.RibbonApplicationMenu ribbonAppMenu;
        private C1.Win.Ribbon.RibbonConfigToolBar ribbonConfigToolBar;
        private C1.Win.Ribbon.RibbonQat ribbonQat;
        private C1.Win.Ribbon.RibbonTab tabCatalogos;
        private C1.Win.Ribbon.RibbonTab tabOperaciones;
        private C1.Win.Ribbon.RibbonTab tabGerencia;
        private C1.Win.Ribbon.RibbonGroup grpCatalogosBase;
        private C1.Win.Ribbon.RibbonGroup grpUsuarios;
        private C1.Win.Ribbon.RibbonGroup grpVentas;
        private C1.Win.Ribbon.RibbonGroup grpAgenda;
        private C1.Win.Ribbon.RibbonGroup grpReportes;
        private C1.Win.Ribbon.RibbonGroup grpSistema;
        private C1.Win.Ribbon.RibbonButton btnCaClientes;
        private C1.Win.Ribbon.RibbonButton btnCaMembresias;
        private C1.Win.Ribbon.RibbonButton btnCaServicios;
        private C1.Win.Ribbon.RibbonButton btnCaEntrenadores;
        private C1.Win.Ribbon.RibbonButton btnCaUsuarios;
        private C1.Win.Ribbon.RibbonButton btnOpInscripcion;
        private C1.Win.Ribbon.RibbonButton btnOpAccesos;
        private C1.Win.Ribbon.RibbonButton btnOpHorarios;
        private C1.Win.Ribbon.RibbonButton btnOpReservas;
        private C1.Win.Ribbon.RibbonButton btnGerenciaReportes;
        private C1.Win.Ribbon.RibbonButton btnSalir;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioLogueado;
        private C1.Win.Ribbon.RibbonBottomToolBar ribbonBottomToolBar1;
        private C1.Win.Ribbon.RibbonTopToolBar ribbonTopToolBar1;
    }
}