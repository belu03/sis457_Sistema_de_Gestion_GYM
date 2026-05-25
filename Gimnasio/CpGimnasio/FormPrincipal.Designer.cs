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
            this.SuspendLayout();
            // 
            // btnUsuario
            // 
            this.btnUsuario.Location = new System.Drawing.Point(69, 57);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(100, 30);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Usuario";
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnEntrenador
            // 
            this.btnEntrenador.Location = new System.Drawing.Point(69, 105);
            this.btnEntrenador.Name = "btnEntrenador";
            this.btnEntrenador.Size = new System.Drawing.Size(100, 30);
            this.btnEntrenador.TabIndex = 1;
            this.btnEntrenador.Text = "Entrenador";
            this.btnEntrenador.Click += new System.EventHandler(this.btnEntrenador_Click);
            // 
            // btnServicio
            // 
            this.btnServicio.Location = new System.Drawing.Point(69, 153);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Size = new System.Drawing.Size(100, 30);
            this.btnServicio.TabIndex = 2;
            this.btnServicio.Text = "Servicio";
            this.btnServicio.Click += new System.EventHandler(this.btnServicio_Click);
            // 
            // btnHorario
            // 
            this.btnHorario.Location = new System.Drawing.Point(69, 201);
            this.btnHorario.Name = "btnHorario";
            this.btnHorario.Size = new System.Drawing.Size(100, 30);
            this.btnHorario.TabIndex = 3;
            this.btnHorario.Text = "Horario";
            this.btnHorario.Click += new System.EventHandler(this.btnHorario_Click);
            // 
            // btnReserva
            // 
            this.btnReserva.Location = new System.Drawing.Point(69, 249);
            this.btnReserva.Name = "btnReserva";
            this.btnReserva.Size = new System.Drawing.Size(100, 30);
            this.btnReserva.TabIndex = 4;
            this.btnReserva.Text = "Reserva";
            this.btnReserva.Click += new System.EventHandler(this.btnReserva_Click);
            // 
            // btnMembresia
            // 
            this.btnMembresia.Location = new System.Drawing.Point(69, 297);
            this.btnMembresia.Name = "btnMembresia";
            this.btnMembresia.Size = new System.Drawing.Size(100, 30);
            this.btnMembresia.TabIndex = 5;
            this.btnMembresia.Text = "Membresía";
            this.btnMembresia.Click += new System.EventHandler(this.btnMembresia_Click);
            // 
            // btnPago
            // 
            this.btnPago.Location = new System.Drawing.Point(69, 345);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(100, 30);
            this.btnPago.TabIndex = 6;
            this.btnPago.Text = "Pago";
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.Location = new System.Drawing.Point(69, 393);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(100, 30);
            this.btnAsistencia.TabIndex = 7;
            this.btnAsistencia.Text = "Asistencia";
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 460);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnEntrenador);
            this.Controls.Add(this.btnServicio);
            this.Controls.Add(this.btnHorario);
            this.Controls.Add(this.btnReserva);
            this.Controls.Add(this.btnMembresia);
            this.Controls.Add(this.btnPago);
            this.Controls.Add(this.btnAsistencia);
            this.Name = "FormPrincipal";
            this.Text = "Sistema Gimnasio";
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
    }
}