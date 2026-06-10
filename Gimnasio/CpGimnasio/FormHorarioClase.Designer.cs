namespace CpGimnasio
{
    partial class FormHorarioClase
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button btnNuevo, btnGuardar, btnEditar, btnEliminar, btnCancelar;
        private System.Windows.Forms.Label lblServicio, lblEntrenador, lblDia, lblHoraInicio, lblHoraFin;
        private System.Windows.Forms.ComboBox cmbServicio, cmbEntrenador, cmbDia;
        private System.Windows.Forms.DateTimePicker dtpHoraInicio, dtpHoraFin;
        private System.Windows.Forms.ErrorProvider erpHorario;
        private System.Windows.Forms.PictureBox pbLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblServicio = new System.Windows.Forms.Label();
            this.cmbServicio = new System.Windows.Forms.ComboBox();
            this.lblEntrenador = new System.Windows.Forms.Label();
            this.cmbEntrenador = new System.Windows.Forms.ComboBox();
            this.lblDia = new System.Windows.Forms.Label();
            this.cmbDia = new System.Windows.Forms.ComboBox();
            this.lblHoraInicio = new System.Windows.Forms.Label();
            this.dtpHoraInicio = new System.Windows.Forms.DateTimePicker();
            this.lblHoraFin = new System.Windows.Forms.Label();
            this.dtpHoraFin = new System.Windows.Forms.DateTimePicker();
            this.erpHorario = new System.Windows.Forms.ErrorProvider(this.components);
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpHorario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLista
            // 
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(300, 80);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.RowHeadersWidth = 62;
            this.dgvLista.Size = new System.Drawing.Size(900, 350);
            this.dgvLista.TabIndex = 1;
            this.dgvLista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLista_CellClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(300, 30);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(700, 26);
            this.txtBuscar.TabIndex = 2;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblBuscar.Location = new System.Drawing.Point(240, 33);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(100, 23);
            this.lblBuscar.TabIndex = 3;
            this.lblBuscar.Text = "Buscar:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(50, 280);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(180, 50);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(1050, 480);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 50);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(900, 480);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(140, 50);
            this.btnEditar.TabIndex = 6;
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(50, 340);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(180, 50);
            this.btnEliminar.TabIndex = 7;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(750, 480);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 50);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblServicio
            // 
            this.lblServicio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblServicio.Location = new System.Drawing.Point(300, 450);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(64, 23);
            this.lblServicio.TabIndex = 9;
            this.lblServicio.Text = "Servicio:";
            // 
            // cmbServicio
            // 
            this.cmbServicio.Location = new System.Drawing.Point(370, 447);
            this.cmbServicio.Name = "cmbServicio";
            this.cmbServicio.Size = new System.Drawing.Size(150, 28);
            this.cmbServicio.TabIndex = 10;
            // 
            // lblEntrenador
            // 
            this.lblEntrenador.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEntrenador.Location = new System.Drawing.Point(540, 450);
            this.lblEntrenador.Name = "lblEntrenador";
            this.lblEntrenador.Size = new System.Drawing.Size(89, 23);
            this.lblEntrenador.TabIndex = 11;
            this.lblEntrenador.Text = "Entrenador:";
            // 
            // cmbEntrenador
            // 
            this.cmbEntrenador.Location = new System.Drawing.Point(638, 447);
            this.cmbEntrenador.Name = "cmbEntrenador";
            this.cmbEntrenador.Size = new System.Drawing.Size(150, 28);
            this.cmbEntrenador.TabIndex = 12;
            // 
            // lblDia
            // 
            this.lblDia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDia.Location = new System.Drawing.Point(797, 450);
            this.lblDia.Name = "lblDia";
            this.lblDia.Size = new System.Drawing.Size(44, 23);
            this.lblDia.TabIndex = 13;
            this.lblDia.Text = "Día:";
            // 
            // cmbDia
            // 
            this.cmbDia.Location = new System.Drawing.Point(851, 447);
            this.cmbDia.Name = "cmbDia";
            this.cmbDia.Size = new System.Drawing.Size(100, 28);
            this.cmbDia.TabIndex = 14;
            // 
            // lblHoraInicio
            // 
            this.lblHoraInicio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHoraInicio.Location = new System.Drawing.Point(300, 490);
            this.lblHoraInicio.Name = "lblHoraInicio";
            this.lblHoraInicio.Size = new System.Drawing.Size(64, 23);
            this.lblHoraInicio.TabIndex = 15;
            this.lblHoraInicio.Text = "Inicio:";
            // 
            // dtpHoraInicio
            // 
            this.dtpHoraInicio.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraInicio.Location = new System.Drawing.Point(370, 487);
            this.dtpHoraInicio.Name = "dtpHoraInicio";
            this.dtpHoraInicio.Size = new System.Drawing.Size(100, 26);
            this.dtpHoraInicio.TabIndex = 16;
            // 
            // lblHoraFin
            // 
            this.lblHoraFin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblHoraFin.Location = new System.Drawing.Point(490, 490);
            this.lblHoraFin.Name = "lblHoraFin";
            this.lblHoraFin.Size = new System.Drawing.Size(54, 23);
            this.lblHoraFin.TabIndex = 17;
            this.lblHoraFin.Text = "Fin:";
            // 
            // dtpHoraFin
            // 
            this.dtpHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraFin.Location = new System.Drawing.Point(550, 487);
            this.dtpHoraFin.Name = "dtpHoraFin";
            this.dtpHoraFin.Size = new System.Drawing.Size(100, 26);
            this.dtpHoraFin.TabIndex = 18;
            // 
            // erpHorario
            // 
            this.erpHorario.ContainerControl = this;
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(30, 20);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 235);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // FormHorarioClase
            // 
            this.ClientSize = new System.Drawing.Size(1250, 580);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.dgvLista);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.cmbServicio);
            this.Controls.Add(this.lblEntrenador);
            this.Controls.Add(this.cmbEntrenador);
            this.Controls.Add(this.lblDia);
            this.Controls.Add(this.cmbDia);
            this.Controls.Add(this.lblHoraInicio);
            this.Controls.Add(this.dtpHoraInicio);
            this.Controls.Add(this.lblHoraFin);
            this.Controls.Add(this.dtpHoraFin);
            this.Name = "FormHorarioClase";
            this.Text = "Gestión de Horarios de Clase";
            this.Load += new System.EventHandler(this.FormHorarioClase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpHorario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}