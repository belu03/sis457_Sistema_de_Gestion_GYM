namespace CpGimnasio
{
    partial class FormPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnEntrenador = new System.Windows.Forms.Button();
            this.btnServicio = new System.Windows.Forms.Button();
            this.btnHorario = new System.Windows.Forms.Button();
            this.btnReserva = new System.Windows.Forms.Button();
            this.btnMembresia = new System.Windows.Forms.Button();
            this.btnPago = new System.Windows.Forms.Button();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pnlSuperior = new System.Windows.Forms.Panel();
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(56, 118);
            this.btnUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(150, 46);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnEntrenador
            // 
            this.btnEntrenador.Location = new System.Drawing.Point(56, 192);
            this.btnEntrenador.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEntrenador.Name = "btnEntrenador";
            this.btnEntrenador.Size = new System.Drawing.Size(150, 46);
            this.btnEntrenador.TabIndex = 1;
            this.btnEntrenador.Text = "Entrenador";
            this.btnEntrenador.Click += new System.EventHandler(this.btnEntrenador_Click);
            // 
            // btnServicio
            // 
            this.btnServicio.Location = new System.Drawing.Point(56, 265);
            this.btnServicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Size = new System.Drawing.Size(150, 46);
            this.btnServicio.TabIndex = 2;
            this.btnServicio.Text = "Servicio";
            this.btnServicio.Click += new System.EventHandler(this.btnServicio_Click);
            // 
            // btnHorario
            // 
            this.btnHorario.Location = new System.Drawing.Point(56, 339);
            this.btnHorario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHorario.Name = "btnHorario";
            this.btnHorario.Size = new System.Drawing.Size(150, 46);
            this.btnHorario.TabIndex = 3;
            this.btnHorario.Text = "Horario";
            this.btnHorario.Click += new System.EventHandler(this.btnHorario_Click);
            // 
            // btnReserva
            // 
            this.btnReserva.Location = new System.Drawing.Point(56, 413);
            this.btnReserva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReserva.Name = "btnReserva";
            this.btnReserva.Size = new System.Drawing.Size(150, 46);
            this.btnReserva.TabIndex = 4;
            this.btnReserva.Text = "Reserva";
            this.btnReserva.Click += new System.EventHandler(this.btnReserva_Click);
            // 
            // btnMembresia
            // 
            this.btnMembresia.Location = new System.Drawing.Point(56, 487);
            this.btnMembresia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMembresia.Name = "btnMembresia";
            this.btnMembresia.Size = new System.Drawing.Size(150, 46);
            this.btnMembresia.TabIndex = 5;
            this.btnMembresia.Text = "Membresía";
            this.btnMembresia.Click += new System.EventHandler(this.btnMembresia_Click);
            // 
            // btnPago
            // 
            this.btnPago.Location = new System.Drawing.Point(56, 561);
            this.btnPago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(150, 46);
            this.btnPago.TabIndex = 6;
            this.btnPago.Text = "Pago";
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.Location = new System.Drawing.Point(56, 635);
            this.btnAsistencia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(150, 46);
            this.btnAsistencia.TabIndex = 7;
            this.btnAsistencia.Text = "Asistencia";
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pnlMenu.Controls.Add(this.btnUsuario);
            this.pnlMenu.Controls.Add(this.pnlLogo);
            this.pnlMenu.Controls.Add(this.btnAsistencia);
            this.pnlMenu.Controls.Add(this.btnEntrenador);
            this.pnlMenu.Controls.Add(this.btnPago);
            this.pnlMenu.Controls.Add(this.btnServicio);
            this.pnlMenu.Controls.Add(this.btnMembresia);
            this.pnlMenu.Controls.Add(this.btnHorario);
            this.pnlMenu.Controls.Add(this.btnReserva);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(273, 708);
            this.pnlMenu.TabIndex = 8;
            // 
            // pnlLogo
            // 
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(273, 100);
            this.pnlLogo.TabIndex = 9;
            // 
            // pnlSuperior
            // 
            this.pnlSuperior.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSuperior.Location = new System.Drawing.Point(273, 0);
            this.pnlSuperior.Name = "pnlSuperior";
            this.pnlSuperior.Size = new System.Drawing.Size(1101, 100);
            this.pnlSuperior.TabIndex = 9;
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(273, 100);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1101, 608);
            this.pnlContenedor.TabIndex = 10;
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 708);
            this.Controls.Add(this.pnlContenedor);
            this.Controls.Add(this.pnlSuperior);
            this.Controls.Add(this.pnlMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormPrincipal";
            this.Text = "Sistema Gimnasio";
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnEntrenador;
        private System.Windows.Forms.Button btnServicio;
        private System.Windows.Forms.Button btnHorario;
        private System.Windows.Forms.Button btnReserva;
        private System.Windows.Forms.Button btnMembresia;
        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.Button btnAsistencia;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel pnlSuperior;
        private System.Windows.Forms.Panel pnlContenedor;
    }
}