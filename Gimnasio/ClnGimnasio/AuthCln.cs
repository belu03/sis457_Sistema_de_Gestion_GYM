using CadGimnasio;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ClnGimnasio
{
    public class AuthCln
    {
        public static UsuarioSistema ValidarLogin(string usuario, string password)
        {
            using (var db = new GimnasioEntities())
            {
                var user = db.UsuarioSistema.FirstOrDefault(u => u.nombre_usuario == usuario && u.activo == true);
                if (user == null) return null;

                string hashGenerado = EncriptarClave(password, user.salt);

                if (user.contraseña.ToUpper() == hashGenerado.ToUpper())
                {
                    return user;
                }
                return null;
            }
        }

        private static string EncriptarClave(string password, string salt)
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
    }
}