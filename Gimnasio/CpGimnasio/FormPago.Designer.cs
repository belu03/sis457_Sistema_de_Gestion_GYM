namespace CpGimnasio
{
    partial class FormPago
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPago));
            this.dgvLista = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.GuardarEntrenador = new System.Windows.Forms.Button();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnUsuario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLista
            // 
            this.dgvLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLista.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLista.Location = new System.Drawing.Point(311, 77);
            this.dgvLista.Name = "dgvLista";
            this.dgvLista.Size = new System.Drawing.Size(1122, 550);
            this.dgvLista.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CpGimnasio.Properties.Resources.PAGO;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(282, 288);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.DarkRed;
            this.btnEditar.Font = new System.Drawing.Font("Impact", 15.75F);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = global::CpGimnasio.Properties.Resources.editar4;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(1254, 728);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(168, 61);
            this.btnEditar.TabIndex = 28;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkRed;
            this.btnEliminar.Font = new System.Drawing.Font("Impact", 15.75F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::CpGimnasio.Properties.Resources.eliminar3;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(66, 380);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(193, 61);
            this.btnEliminar.TabIndex = 27;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Font = new System.Drawing.Font("Impact", 15.75F);
            this.btnNuevo.Image = global::CpGimnasio.Properties.Resources.nuevo_rojo;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(66, 315);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(193, 61);
            this.btnNuevo.TabIndex = 26;
            this.btnNuevo.Text = "Nuevo/Editar";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::CpGimnasio.Properties.Resources.buscar_rojo;
            this.pictureBox2.Location = new System.Drawing.Point(1371, 15);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 56);
            this.pictureBox2.TabIndex = 37;
            this.pictureBox2.TabStop = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Font = new System.Drawing.Font("Impact", 15.75F);
            this.txtBuscar.Location = new System.Drawing.Point(309, 26);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(967, 33);
            this.txtBuscar.TabIndex = 36;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.BackColor = System.Drawing.Color.White;
            this.lblBuscar.Font = new System.Drawing.Font("Impact", 15.75F);
            this.lblBuscar.Location = new System.Drawing.Point(1289, 29);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(74, 26);
            this.lblBuscar.TabIndex = 35;
            this.lblBuscar.Text = "Buscar";
            // 
            // GuardarEntrenador
            // 
            this.GuardarEntrenador.BackColor = System.Drawing.Color.White;
            this.GuardarEntrenador.Font = new System.Drawing.Font("Impact", 15.75F);
            this.GuardarEntrenador.ForeColor = System.Drawing.Color.Black;
            this.GuardarEntrenador.Image = global::CpGimnasio.Properties.Resources.guardar_rojo;
            this.GuardarEntrenador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GuardarEntrenador.Location = new System.Drawing.Point(1070, 728);
            this.GuardarEntrenador.Margin = new System.Windows.Forms.Padding(2);
            this.GuardarEntrenador.Name = "GuardarEntrenador";
            this.GuardarEntrenador.Size = new System.Drawing.Size(163, 61);
            this.GuardarEntrenador.TabIndex = 64;
            this.GuardarEntrenador.Text = "Nuevo";
            this.GuardarEntrenador.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.GuardarEntrenador.UseVisualStyleBackColor = false;
            // 
            // txtCorreo
            // 
            this.txtCorreo.Font = new System.Drawing.Font("Impact", 15.75F);
            this.txtCorreo.Location = new System.Drawing.Point(310, 738);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(2);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(288, 33);
            this.txtCorreo.TabIndex = 63;
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Font = new System.Drawing.Font("Impact", 15.75F);
            this.txtEspecialidad.Location = new System.Drawing.Point(1134, 675);
            this.txtEspecialidad.Margin = new System.Windows.Forms.Padding(2);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(288, 33);
            this.txtEspecialidad.TabIndex = 62;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Impact", 15.75F);
            this.txtTelefono.Location = new System.Drawing.Point(702, 738);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(288, 33);
            this.txtTelefono.TabIndex = 61;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Impact", 15.75F);
            this.txtApellido.Location = new System.Drawing.Point(702, 672);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(288, 33);
            this.txtApellido.TabIndex = 60;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Impact", 15.75F);
            this.txtNombre.Location = new System.Drawing.Point(310, 669);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(288, 33);
            this.txtNombre.TabIndex = 59;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreo.Font = new System.Drawing.Font("Impact", 15.75F);
            this.lblCorreo.ForeColor = System.Drawing.Color.White;
            this.lblCorreo.Location = new System.Drawing.Point(233, 745);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(73, 26);
            this.lblCorreo.TabIndex = 58;
            this.lblCorreo.Text = "Correo";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.BackColor = System.Drawing.Color.Transparent;
            this.lblTelefono.Font = new System.Drawing.Font("Impact", 15.75F);
            this.lblTelefono.ForeColor = System.Drawing.Color.White;
            this.lblTelefono.Location = new System.Drawing.Point(602, 741);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(87, 26);
            this.lblTelefono.TabIndex = 57;
            this.lblTelefono.Text = "Teléfono";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.BackColor = System.Drawing.Color.Transparent;
            this.lblEspecialidad.Font = new System.Drawing.Font("Impact", 15.75F);
            this.lblEspecialidad.ForeColor = System.Drawing.Color.White;
            this.lblEspecialidad.Location = new System.Drawing.Point(1008, 679);
            this.lblEspecialidad.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(122, 26);
            this.lblEspecialidad.TabIndex = 56;
            this.lblEspecialidad.Text = "Especialidad";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.BackColor = System.Drawing.Color.Transparent;
            this.lblApellido.Font = new System.Drawing.Font("Impact", 15.75F);
            this.lblApellido.ForeColor = System.Drawing.Color.White;
            this.lblApellido.Location = new System.Drawing.Point(617, 675);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(81, 26);
            this.lblApellido.TabIndex = 55;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Font = new System.Drawing.Font("Impact", 15.75F);
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(227, 672);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(79, 26);
            this.lblNombre.TabIndex = 54;
            this.lblNombre.Text = "Nombre";
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.Color.Black;
            this.btnUsuario.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.Color.White;
            this.btnUsuario.Location = new System.Drawing.Point(66, 679);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(152, 53);
            this.btnUsuario.TabIndex = 65;
            this.btnUsuario.Text = "Registro de Usuarios";
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // FormPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CpGimnasio.Properties.Resources.gym_fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1444, 804);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.GuardarEntrenador);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.txtEspecialidad);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvLista);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago";
            this.Load += new System.EventHandler(this.FormPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLista;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Button GuardarEntrenador;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnUsuario;
    }
}