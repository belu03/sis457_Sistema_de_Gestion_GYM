using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadGimnasio;

namespace ClnGimnasio
{
    public class UsuarioSistemaCln
    {
        public static UsuarioSistema validar(string usuario, string claveEncriptada)
        {
            using (var context = new GimnasioEntities())
            {
                return context.UsuarioSistema
                    .Where(x => x.nombre_usuario == usuario && x.contraseña == claveEncriptada && x.estado == 1)
                    .FirstOrDefault();
            }
        }

        public static UsuarioSistema obtenerPorNombre(string usuario)
        {
            using (var context = new GimnasioEntities())
            {
                return context.UsuarioSistema
                    .Where(x => x.nombre_usuario == usuario && x.estado == 1)
                    .FirstOrDefault();
            }
        }
    }
}
