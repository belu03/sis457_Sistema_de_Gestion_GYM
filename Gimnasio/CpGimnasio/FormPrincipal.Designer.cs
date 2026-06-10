namespace CpGimnasio
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlMenuLateral;
        private System.Windows.Forms.Button btnRecepcion;
        private System.Windows.Forms.Button btnAgenda;
        private System.Windows.Forms.Button btnAccesos;
        private System.Windows.Forms.Label lblSeparador;
        private System.Windows.Forms.Button btnEntrenadores;
        private System.Windows.Forms.Button btnServicios;
        private System.Windows.Forms.Button btnMembresias;
        private System.Windows.Forms.Button btnUsuariosSistema;
        private System.Windows.Forms.Panel pnlCabecera;
        private System.Windows.Forms.Label lblInfoUsuario;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Panel pnlContenedor;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMenuLateral = new System.Windows.Forms.Panel();
            this.btnRecepcion = new System.Windows.Forms.Button();
            this.btnAgenda = new System.Windows.Forms.Button();
            this.btnAccesos = new System.Windows.Forms.Button();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.btnEntrenadores = new System.Windows.Forms.Button();
            this.btnServicios = new System.Windows.Forms.Button();
            this.btnMembresias = new System.Windows.Forms.Button();
            this.btnUsuariosSistema = new System.Windows.Forms.Button();
            this.pnlCabecera = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblInfoUsuario = new System.Windows.Forms.Label();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlMenuLateral.SuspendLayout();
            this.pnlCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();

            // pnlMenuLateral
            this.pnlMenuLateral.BackColor = System.Drawing.Color.FromArgb(31, 41, 55);
            this.pnlMenuLateral.Controls.Add(this.btnUsuariosSistema);
            this.pnlMenuLateral.Controls.Add(this.btnMembresias);
            this.pnlMenuLateral.Controls.Add(this.btnServicios);
            this.pnlMenuLateral.Controls.Add(this.btnEntrenadores);
            this.pnlMenuLateral.Controls.Add(this.lblSeparador);
            this.pnlMenuLateral.Controls.Add(this.btnAccesos);
            this.pnlMenuLateral.Controls.Add(this.btnAgenda);
            this.pnlMenuLateral.Controls.Add(this.btnRecepcion);
            this.pnlMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuLateral.Location = new System.Drawing.Point(0, 50);
            this.pnlMenuLateral.Size = new System.Drawing.Size(200, 750);

            int yPos = 20;
            this.btnRecepcion.Location = new System.Drawing.Point(0, yPos); this.btnRecepcion.Size = new System.Drawing.Size(200, 45); this.btnRecepcion.Text = "Recepción / Ventas"; this.btnRecepcion.Click += new System.EventHandler(this.btnRecepcion_Click); yPos += 45;
            this.btnAgenda.Location = new System.Drawing.Point(0, yPos); this.btnAgenda.Size = new System.Drawing.Size(200, 45); this.btnAgenda.Text = "Agenda Diaria"; this.btnAgenda.Click += new System.EventHandler(this.btnAgenda_Click); yPos += 45;
            this.btnAccesos.Location = new System.Drawing.Point(0, yPos); this.btnAccesos.Size = new System.Drawing.Size(200, 45); this.btnAccesos.Text = "Monitor de Accesos"; this.btnAccesos.Click += new System.EventHandler(this.btnAccesos_Click); yPos += 60;

            this.lblSeparador.AutoSize = true;
            this.lblSeparador.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSeparador.ForeColor = System.Drawing.Color.Gray;
            this.lblSeparador.Location = new System.Drawing.Point(10, yPos);
            this.lblSeparador.Text = "ADMINISTRACIÓN"; yPos += 30;

            this.btnEntrenadores.Location = new System.Drawing.Point(0, yPos); this.btnEntrenadores.Size = new System.Drawing.Size(200, 45); this.btnEntrenadores.Text = "Entrenadores"; this.btnEntrenadores.Click += new System.EventHandler(this.btnEntrenadores_Click); yPos += 45;
            this.btnServicios.Location = new System.Drawing.Point(0, yPos); this.btnServicios.Size = new System.Drawing.Size(200, 45); this.btnServicios.Text = "Servicios / Clases"; this.btnServicios.Click += new System.EventHandler(this.btnServicios_Click); yPos += 45;
            this.btnMembresias.Location = new System.Drawing.Point(0, yPos); this.btnMembresias.Size = new System.Drawing.Size(200, 45); this.btnMembresias.Text = "Planes Membresía"; this.btnMembresias.Click += new System.EventHandler(this.btnMembresias_Click); yPos += 45;
            this.btnUsuariosSistema.Location = new System.Drawing.Point(0, yPos); this.btnUsuariosSistema.Size = new System.Drawing.Size(200, 45); this.btnUsuariosSistema.Text = "Usuarios Sistema"; this.btnUsuariosSistema.Click += new System.EventHandler(this.btnUsuariosSistema_Click); yPos += 45;

            // pnlCabecera
            this.pnlCabecera.BackColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.pnlCabecera.Controls.Add(this.pbLogo);
            this.pnlCabecera.Controls.Add(this.lblInfoUsuario);
            this.pnlCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCabecera.Size = new System.Drawing.Size(1200, 50);

            // pbLogo
            this.pbLogo.Location = new System.Drawing.Point(10, 5);
            this.pbLogo.Size = new System.Drawing.Size(40, 40);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;

            // lblInfoUsuario
            this.lblInfoUsuario.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblInfoUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInfoUsuario.ForeColor = System.Drawing.Color.White;
            this.lblInfoUsuario.Size = new System.Drawing.Size(380, 50);
            this.lblInfoUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // pnlContenedor
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(200, 50);

            // FormPrincipal
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlMenuLateral);
            this.Controls.Add(this.pnlCabecera);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión - Gimnasio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.pnlMenuLateral.ResumeLayout(false);
            this.pnlMenuLateral.PerformLayout();
            this.pnlCabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
        }
    }
}