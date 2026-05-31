using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnGimnasio
{
    public class EntrenadorCln
    {
        public static int crear(Entrenador entrenador)
        {
            using (var context = new GimnasioEntities())
            {
                context.Entrenador.Add(entrenador);
                context.SaveChanges();
                return entrenador.id;
            }
        }

        public static int modificar(Entrenador entrenador)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Entrenador.Find(entrenador.id);
                if (existente != null)
                {
                    existente.nombre = entrenador.nombre;
                    existente.apellido = entrenador.apellido;
                    existente.especialidad = entrenador.especialidad;
                    existente.telefono = entrenador.telefono;
                    existente.correo = entrenador.correo;
                    return context.SaveChanges();

                }
                else
                {
                    return 0; // Entrenador no encontrado
                }
            }
        }

        public static int eliminar(int id)
        {
            using (var context = new GimnasioEntities())
            {
                var entrenador = context.Entrenador.Find(id); // <--- ¿Aquí encuentra el entrendor?
                if (entrenador != null)
                {
                    context.Entrenador.Remove(entrenador);
                    return context.SaveChanges();
                }
                return 0;
            }
        }
        public static Entrenador obtenerUno(int id)
        {
            using (var context = new GimnasioEntities())
            {
                return context.Entrenador.Find(id);
            }
        }

        public static List<Entrenador> listar()
        {
            using (var context = new GimnasioEntities())
            {
                context.Configuration.LazyLoadingEnabled = false; // AGREGA ESTA LÍNEA
                return context.Entrenador.ToList();
            }
        }

        public static List<Entrenador> listar(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                // Esto busca en la tabla real, sin importar el procedimiento almacenado
                return context.Entrenador
                    .Where(u => u.nombre.Contains(parametro) || u.apellido.Contains(parametro))
                    .ToList();
            }
        }
    }
}