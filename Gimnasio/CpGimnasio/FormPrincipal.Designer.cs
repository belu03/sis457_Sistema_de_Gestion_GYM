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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.pnlContenedor = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnAsistencia = new System.Windows.Forms.Button();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.btnEntrenador = new System.Windows.Forms.Button();
            this.btnReserva = new System.Windows.Forms.Button();
            this.btnPago = new System.Windows.Forms.Button();
            this.btnHorario = new System.Windows.Forms.Button();
            this.btnServicio = new System.Windows.Forms.Button();
            this.btnMembresia = new System.Windows.Forms.Button();
            this.pnlContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContenedor
            // 
            this.pnlContenedor.BackgroundImage = global::CpGimnasio.Properties.Resources.gym_fondo;
            this.pnlContenedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlContenedor.Controls.Add(this.pictureBox2);
            this.pnlContenedor.Controls.Add(this.pictureBox1);
            this.pnlContenedor.Controls.Add(this.txtBuscar);
            this.pnlContenedor.Controls.Add(this.lblBuscar);
            this.pnlContenedor.Controls.Add(this.btnUsuario);
            this.pnlContenedor.Controls.Add(this.btnAsistencia);
            this.pnlContenedor.Controls.Add(this.dgvLista);
            this.pnlContenedor.Controls.Add(this.btnEntrenador);
            this.pnlContenedor.Controls.Add(this.btnReserva);
            this.pnlContenedor.Controls.Add(this.btnPago);
            this.pnlContenedor.Controls.Add(this.btnHorario);
            this.pnlContenedor.Controls.Add(this.btnServicio);
            this.pnlContenedor.Controls.Add(this.btnMembresia);
            this.pnlContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedor.Location = new System.Drawing.Point(0, 0);
            this.pnlContenedor.Margin = new System.Windows.Forms.Padding(2);
            this.pnlContenedor.Name = "pnlContenedor";
            this.pnlContenedor.Size = new System.Drawing.Size(1460, 835);
            this.pnlContenedor.TabIndex = 10;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::CpGimnasio.Properties.Resources.buscar_rojo;
            this.pictureBox2.Location = new System.Drawing.Point(1380, 51);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 56);
            this.pictureBox2.TabIndex = 40;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CpGimnasio.Properties.Resources.gym_logo_2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 288);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Impact", 15.75F);
            this.txtBuscar.Location = new System.Drawing.Point(318, 62);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(967, 33);
            this.txtBuscar.TabIndex = 39;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.BackColor = System.Drawing.Color.White;
            this.lblBuscar.Font = new System.Drawing.Font("Impact", 15.75F);
            this.lblBuscar.Location = new System.Drawing.Point(1298, 65);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(74, 26);
            this.lblBuscar.TabIndex = 38;
            this.lblBuscar.Text = "Buscar";
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.Color.Black;
            this.btnUsuario.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.Color.White;
            this.btnUsuario.Location = new System.Drawing.Point(70, 320);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(152, 53);
            this.btnUsuario.TabIndex = 0;
            this.btnUsuario.Text = "Registro de Usuarios";
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnAsistencia
            // 
            this.btnAsistencia.BackColor = System.Drawing.Color.Black;
            this.btnAsistencia.Font = new System.Drawing.Font("Impact", 15.75F);
            this.btnAsistencia.ForeColor = System.Drawing.Color.White;
            this.btnAsistencia.Location = new System.Drawing.Point(70, 713);
            this.btnAsistencia.Name = "btnAsistencia";
            this.btnAsistencia.Size = new System.Drawing.Size(152, 53);
            this.btnAsistencia.TabIndex = 7;
            this.btnAsistencia.Text = "Asistencia";
            this.btnAsistencia.UseVisualStyleBackColor = false;
            this.btnAsistencia.Click += new System.EventHandler(this.btnAsistencia_Click);
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(300, 139);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(1138, 684);
            this.dgvLista.TabIndex = 0;
            // 
            // btnEntrenador
            // 
            this.btnEntrenador.BackColor = System.Drawing.Color.Black;
            this.btnEntrenador.Font = new System.Drawing.Font("Impact", 15.75F);
            this.btnEntrenador.ForeColor = System.Drawing.Color.White;
            this.btnEntrenador.Location = new System.Drawing.Point(70, 379);
            this.btnEntrenador.Name = "btnEntrenador";
            this.btnEntrenador.Size = new System.Drawing.Size(152, 53);
            this.btnEntrenador.TabIndex = 1;
            this.btnEntrenador.Text = "Entrenador";
            this.btnEntrenador.UseVisualStyleBackColor = false;
            this.btnEntrenador.Click += new System.EventHandler(this.btnEntrenador_Click);
            // 
            // btnReserva
            // 
            this.btnReserva.BackColor = System.Drawing.Color.Black;
            this.btnReserva.Font = new System.Drawing.Font("Impact", 15.75F);
            this.btnReserva.ForeColor = System.Drawing.Color.White;
            this.btnReserva.Location = new System.Drawing.Point(70, 547);
            this.btnReserva.Name = "btnReserva";
            this.btnReserva.Size = new System.Drawing.Size(152, 53);
            this.btnReserva.TabIndex = 4;
            this.btnReserva.Text = "Reserva";
            this.btnReserva.UseVisualStyleBackColor = false;
            this.btnReserva.Click += new System.EventHandler(this.btnReserva_Click);
            // 
            // btnPago
            // 
            this.btnPago.BackColor = System.Drawing.Color.Black;
            this.btnPago.Font = new System.Drawing.Font("Impact", 15.75F);
            this.btnPago.ForeColor = System.Drawing.Color.White;
            this.btnPago.Location = new System.Drawing.Point(70, 658);
            this.btnPago.Name = "btnPago";
            this.btnPago.Size = new System.Drawing.Size(152, 53);
            this.btnPago.TabIndex = 6;
            this.btnPago.Text = "Pago";
            this.btnPago.UseVisualStyleBackColor = false;
            this.btnPago.Click += new System.EventHandler(this.btnPago_Click);
            // 
            // btnHorario
            // 
            this.btnHorario.BackColor = System.Drawing.Color.Black;
            this.btnHorario.Font = new System.Drawing.Font("Impact", 15.75F);
            this.btnHorario.ForeColor = System.Drawing.Color.White;
            this.btnHorario.Location = new System.Drawing.Point(70, 491);
            this.btnHorario.Name = "btnHorario";
            this.btnHorario.Size = new System.Drawing.Size(152, 53);
            this.btnHorario.TabIndex = 3;
            this.btnHorario.Text = "Horario";
            this.btnHorario.UseVisualStyleBackColor = false;
            this.btnHorario.Click += new System.EventHandler(this.btnHorario_Click);
            // 
            // btnServicio
            // 
            this.btnServicio.BackColor = System.Drawing.Color.Black;
            this.btnServicio.Font = new System.Drawing.Font("Impact", 15.75F);
            this.btnServicio.ForeColor = System.Drawing.Color.White;
            this.btnServicio.Location = new System.Drawing.Point(70, 436);
            this.btnServicio.Name = "btnServicio";
            this.btnServicio.Size = new System.Drawing.Size(152, 53);
            this.btnServicio.TabIndex = 2;
            this.btnServicio.Text = "Servicio";
            this.btnServicio.UseVisualStyleBackColor = false;
            this.btnServicio.Click += new System.EventHandler(this.btnServicio_Click);
            // 
            // btnMembresia
            // 
            this.btnMembresia.BackColor = System.Drawing.Color.Black;
            this.btnMembresia.Font = new System.Drawing.Font("Impact", 15.75F);
            this.btnMembresia.ForeColor = System.Drawing.Color.White;
            this.btnMembresia.Location = new System.Drawing.Point(70, 603);
            this.btnMembresia.Name = "btnMembresia";
            this.btnMembresia.Size = new System.Drawing.Size(152, 53);
            this.btnMembresia.TabIndex = 5;
            this.btnMembresia.Text = "Membresía";
            this.btnMembresia.UseVisualStyleBackColor = false;
            this.btnMembresia.Click += new System.EventHandler(this.btnMembresia_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1460, 835);
            this.Controls.Add(this.pnlContenedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Gimnasio";
            this.pnlContenedor.ResumeLayout(false);
            this.pnlContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Panel pnlContenedor;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.Button btnReserva;
        private System.Windows.Forms.Button btnHorario;
        private System.Windows.Forms.Button btnMembresia;
        private System.Windows.Forms.Button btnServicio;
        private System.Windows.Forms.Button btnPago;
        private System.Windows.Forms.Button btnEntrenador;
        private System.Windows.Forms.Button btnAsistencia;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
    }
}