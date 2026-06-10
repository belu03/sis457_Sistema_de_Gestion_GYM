namespace CpGimnasio
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.PictureBox pbLogo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();

            // pbLogo
            this.pbLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbLogo.Location = new System.Drawing.Point(75, 20);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(200, 100);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;

            // lblTitulo
            this.lblTitulo.Text = "ACCESO AL SISTEMA";
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Location = new System.Drawing.Point(0, 130);
            this.lblTitulo.Size = new System.Drawing.Size(350, 40);
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblUsuario
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Location = new System.Drawing.Point(50, 190);
            this.lblUsuario.Size = new System.Drawing.Size(80, 20);

            // txtUsuario
            this.txtUsuario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuario.Location = new System.Drawing.Point(50, 215);
            this.txtUsuario.Size = new System.Drawing.Size(250, 25);

            // lblContraseña
            this.lblContraseña.Text = "Contraseña:";
            this.lblContraseña.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblContraseña.ForeColor = System.Drawing.Color.White;
            this.lblContraseña.BackColor = System.Drawing.Color.Transparent;
            this.lblContraseña.Location = new System.Drawing.Point(50, 255);
            this.lblContraseña.Size = new System.Drawing.Size(100, 20);

            // txtContraseña
            this.txtContraseña.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtContraseña.Location = new System.Drawing.Point(50, 280);
            this.txtContraseña.Size = new System.Drawing.Size(250, 25);
            this.txtContraseña.PasswordChar = '*';

            // btnIngresar
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.Location = new System.Drawing.Point(50, 330);
            this.btnIngresar.Size = new System.Drawing.Size(120, 45);
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);

            // btnSalir
            this.btnSalir.Text = "Salir";
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSalir.Location = new System.Drawing.Point(180, 330);
            this.btnSalir.Size = new System.Drawing.Size(120, 45);
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

            // FormLogin
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 420);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContraseña);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.btnSalir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Gimnasio";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}