namespace CpGimnasio
{
    partial class FormAgenda
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvClases;
        private System.Windows.Forms.Label lblTituloClases;
        private System.Windows.Forms.DataGridView dgvReservas;
        private System.Windows.Forms.Label lblClaseSeleccionada;
        private System.Windows.Forms.TextBox txtCIReserva;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Label lblInstruccion;
        private System.Windows.Forms.Panel pnlDerecho;
        private System.Windows.Forms.ComboBox cmbFiltroDia;
        private System.Windows.Forms.Label lblFiltroDia;
        private System.Windows.Forms.Button btnGestionarHorarios;
        private System.Windows.Forms.PictureBox pbLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvClases = new System.Windows.Forms.DataGridView();
            this.lblTituloClases = new System.Windows.Forms.Label();
            this.dgvReservas = new System.Windows.Forms.DataGridView();
            this.lblClaseSeleccionada = new System.Windows.Forms.Label();
            this.txtCIReserva = new System.Windows.Forms.TextBox();
            this.btnReservar = new System.Windows.Forms.Button();
            this.lblInstruccion = new System.Windows.Forms.Label();
            this.pnlDerecho = new System.Windows.Forms.Panel();
            this.cmbFiltroDia = new System.Windows.Forms.ComboBox();
            this.lblFiltroDia = new System.Windows.Forms.Label();
            this.btnGestionarHorarios = new System.Windows.Forms.Button();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).BeginInit();
            this.pnlDerecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClases
            // 
            this.dgvClases.ColumnHeadersHeight = 34;
            this.dgvClases.Location = new System.Drawing.Point(45, 154);
            this.dgvClases.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvClases.Name = "dgvClases";
            this.dgvClases.RowHeadersWidth = 62;
            this.dgvClases.Size = new System.Drawing.Size(810, 662);
            this.dgvClases.TabIndex = 5;
            this.dgvClases.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClases_CellClick);
            // 
            // lblTituloClases
            // 
            this.lblTituloClases.AutoSize = true;
            this.lblTituloClases.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloClases.Location = new System.Drawing.Point(45, 108);
            this.lblTituloClases.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloClases.Name = "lblTituloClases";
            this.lblTituloClases.Size = new System.Drawing.Size(186, 28);
            this.lblTituloClases.TabIndex = 6;
            this.lblTituloClases.Text = "Horarios de Clases";
            // 
            // dgvReservas
            // 
            this.dgvReservas.ColumnHeadersHeight = 34;
            this.dgvReservas.Location = new System.Drawing.Point(22, 69);
            this.dgvReservas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvReservas.Name = "dgvReservas";
            this.dgvReservas.RowHeadersWidth = 62;
            this.dgvReservas.Size = new System.Drawing.Size(660, 446);
            this.dgvReservas.TabIndex = 1;
            // 
            // lblClaseSeleccionada
            // 
            this.lblClaseSeleccionada.AutoSize = true;
            this.lblClaseSeleccionada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblClaseSeleccionada.Location = new System.Drawing.Point(22, 23);
            this.lblClaseSeleccionada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClaseSeleccionada.Name = "lblClaseSeleccionada";
            this.lblClaseSeleccionada.Size = new System.Drawing.Size(221, 28);
            this.lblClaseSeleccionada.TabIndex = 0;
            this.lblClaseSeleccionada.Text = "Seleccione una clase...";
            // 
            // txtCIReserva
            // 
            this.txtCIReserva.Location = new System.Drawing.Point(22, 577);
            this.txtCIReserva.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCIReserva.Name = "txtCIReserva";
            this.txtCIReserva.Size = new System.Drawing.Size(328, 26);
            this.txtCIReserva.TabIndex = 3;
            // 
            // btnReservar
            // 
            this.btnReservar.Location = new System.Drawing.Point(375, 569);
            this.btnReservar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(270, 46);
            this.btnReservar.TabIndex = 4;
            this.btnReservar.Text = "Reservar Cupo";
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // lblInstruccion
            // 
            this.lblInstruccion.AutoSize = true;
            this.lblInstruccion.Location = new System.Drawing.Point(22, 546);
            this.lblInstruccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstruccion.Name = "lblInstruccion";
            this.lblInstruccion.Size = new System.Drawing.Size(149, 20);
            this.lblInstruccion.TabIndex = 2;
            this.lblInstruccion.Text = "Anotar Alumno (CI):";
            // 
            // pnlDerecho
            // 
            this.pnlDerecho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.pnlDerecho.Controls.Add(this.lblClaseSeleccionada);
            this.pnlDerecho.Controls.Add(this.dgvReservas);
            this.pnlDerecho.Controls.Add(this.lblInstruccion);
            this.pnlDerecho.Controls.Add(this.txtCIReserva);
            this.pnlDerecho.Controls.Add(this.btnReservar);
            this.pnlDerecho.Location = new System.Drawing.Point(885, 154);
            this.pnlDerecho.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlDerecho.Name = "pnlDerecho";
            this.pnlDerecho.Size = new System.Drawing.Size(705, 662);
            this.pnlDerecho.TabIndex = 4;
            // 
            // cmbFiltroDia
            // 
            this.cmbFiltroDia.Location = new System.Drawing.Point(172, 34);
            this.cmbFiltroDia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbFiltroDia.Name = "cmbFiltroDia";
            this.cmbFiltroDia.Size = new System.Drawing.Size(178, 28);
            this.cmbFiltroDia.TabIndex = 3;
            // 
            // lblFiltroDia
            // 
            this.lblFiltroDia.AutoSize = true;
            this.lblFiltroDia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblFiltroDia.Location = new System.Drawing.Point(45, 38);
            this.lblFiltroDia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltroDia.Name = "lblFiltroDia";
            this.lblFiltroDia.Size = new System.Drawing.Size(105, 20);
            this.lblFiltroDia.TabIndex = 2;
            this.lblFiltroDia.Text = "Filtrar por día:";
            // 
            // btnGestionarHorarios
            // 
            this.btnGestionarHorarios.Location = new System.Drawing.Point(1245, 28);
            this.btnGestionarHorarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGestionarHorarios.Name = "btnGestionarHorarios";
            this.btnGestionarHorarios.Size = new System.Drawing.Size(240, 46);
            this.btnGestionarHorarios.TabIndex = 1;
            this.btnGestionarHorarios.Text = "Gestionar Horarios";
            this.btnGestionarHorarios.Click += new System.EventHandler(this.btnGestionarHorarios_Click);
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(431, 14);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(154, 114);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // FormAgenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1620, 892);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.btnGestionarHorarios);
            this.Controls.Add(this.lblFiltroDia);
            this.Controls.Add(this.cmbFiltroDia);
            this.Controls.Add(this.pnlDerecho);
            this.Controls.Add(this.dgvClases);
            this.Controls.Add(this.lblTituloClases);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormAgenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tablero de Agenda Diaria";
            this.Load += new System.EventHandler(this.FormAgenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservas)).EndInit();
            this.pnlDerecho.ResumeLayout(false);
            this.pnlDerecho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}