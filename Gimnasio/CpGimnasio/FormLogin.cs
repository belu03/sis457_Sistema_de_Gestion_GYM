using ClnGimnasio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpGimnasio
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // 1. Obtenemos lo que la recepcionista escribió
            string usuario = txtUsuarioS.Text.Trim();
            string contrasena = txtContraseña.Text.Trim();

            // 2. Validamos que no deje los campos vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Llamamos a nuestra capa de negocio
            var usuarioLogueado = UsuarioSistemaCln.ValidarLogin(usuario, contrasena);

            // 4. Verificamos el resultado
            if (usuarioLogueado != null)
            {
                MessageBox.Show($"¡Bienvenido(a) al sistema, {usuarioLogueado.nombre}!", "Ingreso Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Abrimos el menú principal (Asegúrate de tener un Form llamado FormPrincipal)
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();

                // Ocultamos la ventana de Login
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Intente nuevamente.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear(); // Limpiamos el campo respetando la ñ
                txtContraseña.Focus();
            }
         
        }
    }
}
