using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnGimnasio
{
    public class UsuarioCln
    {
        public static int crear(Usuario usuario)
        {
            using (var context = new GimnasioEntities())
            {
                context.Usuario.Add(usuario);
                context.SaveChanges();
                return usuario.id;
            }
        }

        public static int modificar(Usuario usuario)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Usuario.Find(usuario.id);
                if (existente != null)
                {
                    existente.nombre = usuario.nombre;
                    existente.apellido = usuario.apellido;
                    existente.correo = usuario.correo;
                    existente.telefono = usuario.telefono;
                    return context.SaveChanges();

                }
                else
                {
                    return 0; // Usuario no encontrado
                }
            }
        }

        public static int eliminar(int id)
        {
            using (var context = new GimnasioEntities())
            {
                var usuario = context.Usuario.Find(id); // <--- ¿Aquí encuentra el usuario?
                if (usuario != null)
                {
                    context.Usuario.Remove(usuario);
                    return context.SaveChanges();
                }
                return 0;
            }
        }
        public static Usuario obtenerUno(int id)
        {
            using (var context = new GimnasioEntities())
            {
                return context.Usuario.Find(id);
            }
        }

        public static List<Usuario> listar()
        {
            using (var context = new GimnasioEntities())
            {
                context.Configuration.LazyLoadingEnabled = false; // AGREGA ESTA LÍNEA
                return context.Usuario.ToList();
            }
        }

        public static List<Usuario> listar(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                // Esto busca en la tabla real, sin importar el procedimiento almacenado
                return context.Usuario
                    .Where(u => u.nombre.Contains(parametro) || u.apellido.Contains(parametro))
                    .ToList();
            }
        }
    }
}