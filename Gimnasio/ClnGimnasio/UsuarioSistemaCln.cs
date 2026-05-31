using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClnGimnasio
{
    public class UsuarioSistemaCln
    {
        // 1. Método que encripta la contraseña usando SHA-256
        public static string EncriptarClave(string contraseñaPlana)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convierte el texto a bytes
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(contraseñaPlana));

                // Lo convierte a una cadena Base64 (similar al ejemplo que enviaste)
                return Convert.ToBase64String(bytes);
            }
        }

        // 2. Método de validación actualizado
        public static UsuarioSistema ValidarLogin(string nombreUsuario, string contrasenaUsuario)
        {
            string contrasenaEncriptada = EncriptarClave(contrasenaUsuario);

            using (var context = new GimnasioEntities())
            {
                // Comparamos directamente. Si no coincide, devolverá null y el FormLogin mostrará el mensaje de error normal.
                var usuario = context.UsuarioSistema
                                     .FirstOrDefault(u => u.nombre == nombreUsuario && u.contraseña == contrasenaEncriptada);

                return usuario;
            }
        }
      
    }
}
