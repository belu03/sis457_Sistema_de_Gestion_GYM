namespace CpGimnasio
{
    partial class FormInscripcion
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.GroupBox gbCliente;
        private System.Windows.Forms.Label lblEstadoMembresia;
        private System.Windows.Forms.Button btnBuscarCI;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtCI;
        private System.Windows.Forms.Label lblCI;
        private System.Windows.Forms.GroupBox gbInscripcion;
        private System.Windows.Forms.ComboBox cmbMetodoPago;
        private System.Windows.Forms.Label lblMetodoPago;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.ComboBox cmbMembresia;
        private System.Windows.Forms.Label lblMembresia;
        private System.Windows.Forms.Label lblMontoPagar;
        private System.Windows.Forms.Button btnCobrar;
        private System.Windows.Forms.PictureBox pbLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.gbCliente = new System.Windows.Forms.GroupBox();
            this.lblEstadoMembresia = new System.Windows.Forms.Label();
            this.btnBuscarCI = new System.Windows.Forms.Button();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtCI = new System.Windows.Forms.TextBox();
            this.lblCI = new System.Windows.Forms.Label();
            this.gbInscripcion = new System.Windows.Forms.GroupBox();
            this.cmbMetodoPago = new System.Windows.Forms.ComboBox();
            this.lblMetodoPago = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblInicio = new System.Windows.Forms.Label();
            this.cmbMembresia = new System.Windows.Forms.ComboBox();
            this.lblMembresia = new System.Windows.Forms.Label();
            this.btnCobrar = new System.Windows.Forms.Button();
            this.lblMontoPagar = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbCliente.SuspendLayout();
            this.gbInscripcion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.White;
            this.lblTituloPrincipal.Location = new System.Drawing.Point(135, 31);
            this.lblTituloPrincipal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(1155, 62);
            this.lblTituloPrincipal.TabIndex = 1;
            this.lblTituloPrincipal.Text = "PUNTO DE VENTA: NUEVA INSCRIPCIÓN / RENOVACIÓN";
            // 
            // gbCliente
            // 
            this.gbCliente.Controls.Add(this.lblEstadoMembresia);
            this.gbCliente.Controls.Add(this.btnBuscarCI);
            this.gbCliente.Controls.Add(this.txtCorreo);
            this.gbCliente.Controls.Add(this.lblCorreo);
            this.gbCliente.Controls.Add(this.txtTelefono);
            this.gbCliente.Controls.Add(this.lblTelefono);
            this.gbCliente.Controls.Add(this.txtApellido);
            this.gbCliente.Controls.Add(this.lblApellido);
            this.gbCliente.Controls.Add(this.txtNombre);
            this.gbCliente.Controls.Add(this.lblNombre);
            this.gbCliente.Controls.Add(this.txtCI);
            this.gbCliente.Controls.Add(this.lblCI);
            this.gbCliente.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gbCliente.Location = new System.Drawing.Point(45, 123);
            this.gbCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCliente.Name = "gbCliente";
            this.gbCliente.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbCliente.Size = new System.Drawing.Size(600, 492);
            this.gbCliente.TabIndex = 2;
            this.gbCliente.TabStop = false;
            this.gbCliente.Text = "1. Datos del Cliente";
            // 
            // lblEstadoMembresia
            // 
            this.lblEstadoMembresia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstadoMembresia.Location = new System.Drawing.Point(30, 431);
            this.lblEstadoMembresia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstadoMembresia.Name = "lblEstadoMembresia";
            this.lblEstadoMembresia.Size = new System.Drawing.Size(540, 38);
            this.lblEstadoMembresia.TabIndex = 0;
            // 
            // btnBuscarCI
            // 
            this.btnBuscarCI.Location = new System.Drawing.Point(390, 54);
            this.btnBuscarCI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscarCI.Name = "btnBuscarCI";
            this.btnBuscarCI.Size = new System.Drawing.Size(180, 46);
            this.btnBuscarCI.TabIndex = 1;
            this.btnBuscarCI.Text = "Buscar / Nuevo";
            this.btnBuscarCI.Click += new System.EventHandler(this.btnBuscarCI_Click);
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(150, 368);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(418, 33);
            this.txtCorreo.TabIndex = 2;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(30, 372);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(76, 28);
            this.lblCorreo.TabIndex = 3;
            this.lblCorreo.Text = "Correo:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(150, 291);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(418, 33);
            this.txtTelefono.TabIndex = 4;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(30, 295);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(90, 28);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(150, 214);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(418, 33);
            this.txtApellido.TabIndex = 6;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(30, 218);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(98, 28);
            this.lblApellido.TabIndex = 7;
            this.lblApellido.Text = "Apellidos:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(150, 137);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(418, 33);
            this.txtNombre.TabIndex = 8;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(30, 142);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(97, 28);
            this.lblNombre.TabIndex = 9;
            this.lblNombre.Text = "Nombres:";
            // 
            // txtCI
            // 
            this.txtCI.Location = new System.Drawing.Point(150, 58);
            this.txtCI.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtCI.Name = "txtCI";
            this.txtCI.Size = new System.Drawing.Size(223, 33);
            this.txtCI.TabIndex = 10;
            // 
            // lblCI
            // 
            this.lblCI.AutoSize = true;
            this.lblCI.Location = new System.Drawing.Point(30, 65);
            this.lblCI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCI.Name = "lblCI";
            this.lblCI.Size = new System.Drawing.Size(107, 28);
            this.lblCI.TabIndex = 11;
            this.lblCI.Text = "Carnet (CI):";
            // 
            // gbInscripcion
            // 
            this.gbInscripcion.Controls.Add(this.cmbMetodoPago);
            this.gbInscripcion.Controls.Add(this.lblMetodoPago);
            this.gbInscripcion.Controls.Add(this.dtpInicio);
            this.gbInscripcion.Controls.Add(this.lblInicio);
            this.gbInscripcion.Controls.Add(this.cmbMembresia);
            this.gbInscripcion.Controls.Add(this.lblMembresia);
            this.gbInscripcion.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.gbInscripcion.Location = new System.Drawing.Point(690, 123);
            this.gbInscripcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbInscripcion.Name = "gbInscripcion";
            this.gbInscripcion.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbInscripcion.Size = new System.Drawing.Size(600, 308);
            this.gbInscripcion.TabIndex = 3;
            this.gbInscripcion.TabStop = false;
            this.gbInscripcion.Text = "2. Plan y Pago";
            // 
            // cmbMetodoPago
            // 
            this.cmbMetodoPago.FormattingEnabled = true;
            this.cmbMetodoPago.Location = new System.Drawing.Point(210, 214);
            this.cmbMetodoPago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMetodoPago.Name = "cmbMetodoPago";
            this.cmbMetodoPago.Size = new System.Drawing.Size(358, 36);
            this.cmbMetodoPago.TabIndex = 0;
            // 
            // lblMetodoPago
            // 
            this.lblMetodoPago.AutoSize = true;
            this.lblMetodoPago.Location = new System.Drawing.Point(30, 218);
            this.lblMetodoPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMetodoPago.Name = "lblMetodoPago";
            this.lblMetodoPago.Size = new System.Drawing.Size(163, 28);
            this.lblMetodoPago.TabIndex = 1;
            this.lblMetodoPago.Text = "Método de Pago:";
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(210, 132);
            this.dtpInicio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(358, 33);
            this.dtpInicio.TabIndex = 2;
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Location = new System.Drawing.Point(30, 142);
            this.lblInicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(81, 28);
            this.lblInicio.TabIndex = 3;
            this.lblInicio.Text = "Inicia el:";
            // 
            // cmbMembresia
            // 
            this.cmbMembresia.FormattingEnabled = true;
            this.cmbMembresia.Location = new System.Drawing.Point(210, 60);
            this.cmbMembresia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMembresia.Name = "cmbMembresia";
            this.cmbMembresia.Size = new System.Drawing.Size(358, 36);
            this.cmbMembresia.TabIndex = 4;
            this.cmbMembresia.SelectedIndexChanged += new System.EventHandler(this.cmbMembresia_SelectedIndexChanged);
            // 
            // lblMembresia
            // 
            this.lblMembresia.AutoSize = true;
            this.lblMembresia.Location = new System.Drawing.Point(30, 65);
            this.lblMembresia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMembresia.Name = "lblMembresia";
            this.lblMembresia.Size = new System.Drawing.Size(174, 28);
            this.lblMembresia.TabIndex = 5;
            this.lblMembresia.Text = "Plan Seleccionado:";
            // 
            // btnCobrar
            // 
            this.btnCobrar.Location = new System.Drawing.Point(690, 523);
            this.btnCobrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCobrar.Name = "btnCobrar";
            this.btnCobrar.Size = new System.Drawing.Size(600, 92);
            this.btnCobrar.TabIndex = 4;
            this.btnCobrar.Text = "COBRAR E INSCRIBIR";
            this.btnCobrar.Click += new System.EventHandler(this.btnCobrar_Click);
            // 
            // lblMontoPagar
            // 
            this.lblMontoPagar.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblMontoPagar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(29)))), ((int)(((byte)(72)))));
            this.lblMontoPagar.Location = new System.Drawing.Point(690, 446);
            this.lblMontoPagar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMontoPagar.Name = "lblMontoPagar";
            this.lblMontoPagar.Size = new System.Drawing.Size(600, 62);
            this.lblMontoPagar.TabIndex = 5;
            this.lblMontoPagar.Text = "Total a Pagar: 0.00 Bs.";
            this.lblMontoPagar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbLogo
            // 
            this.pbLogo.Location = new System.Drawing.Point(60, 664);
            this.pbLogo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(258, 245);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // FormInscripcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1346, 923);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblTituloPrincipal);
            this.Controls.Add(this.gbCliente);
            this.Controls.Add(this.gbInscripcion);
            this.Controls.Add(this.btnCobrar);
            this.Controls.Add(this.lblMontoPagar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormInscripcion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módulo de Recepción";
            this.Load += new System.EventHandler(this.FormInscripcion_Load);
            this.gbCliente.ResumeLayout(false);
            this.gbCliente.PerformLayout();
            this.gbInscripcion.ResumeLayout(false);
            this.gbInscripcion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}