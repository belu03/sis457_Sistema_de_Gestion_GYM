using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClnGimnasio;
using System.Security.Cryptography;

namespace CpGimnasio
{
    public partial class FrmAutenticacion : Form
    {
        public FrmAutenticacion()
        {
            InitializeComponent();
        }

        private bool validar()
        {
            bool esValido = true;
            erpUsuario.Clear();
            erpClave.Clear();

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                erpUsuario.SetError(txtUsuario, "El usuario es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                erpClave.SetError(txtClave, "La contraseña es obligatoria");
                esValido = false;
            }

            return esValido;
        }

        // Método local para encriptar la clave igual que en la Base de Datos
        private string EncriptarClave(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                // 1. Obtenemos el usuario solo para saber su "salt"
                var userTemp = UsuarioSistemaCln.obtenerPorNombre(txtUsuario.Text.Trim());

                if (userTemp != null)
                {
                    // 2. Encriptamos la clave ingresada usando el salt de la BD
                    string claveHash = EncriptarClave(txtClave.Text.Trim(), userTemp.salt);

                    // 3. Validamos estilo Minerva
                    var usuario = UsuarioSistemaCln.validar(txtUsuario.Text.Trim(), claveHash);

                    if (usuario != null)
                    {
                        Util.usuario = usuario; // Guardamos la sesión activa
                        txtClave.Clear();
                        txtUsuario.Focus();
                        txtUsuario.SelectAll();
                        Hide();
                        new FrmPrincipal(this).ShowDialog(); // Abrimos el principal
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta", "::: Mensaje - Gimnasio :::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no existe o está inactivo", "::: Mensaje - Gimnasio :::", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnIngresar.PerformClick();
        }

        private void FrmAutenticacion_Load(object sender, EventArgs e)
        {

        }
    }
}
