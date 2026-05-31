using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnGimnasio
{
    public class ServicioCln
    {
        public static int crear(Servicio servicio)
        {
            using (var context = new GimnasioEntities())
            {
                context.Servicio.Add(servicio);
                context.SaveChanges();
                return servicio.id;
            }
        }

        public static int modificar(Servicio servicio)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Servicio.Find(servicio.id);
                if (existente != null)
                {
                    existente.nombre = servicio.nombre;
                    existente.descripcion = servicio.descripcion;
                    existente.duracion = servicio.duracion;
                    existente.capacidad_maxima = servicio.capacidad_maxima;
                    return context.SaveChanges();

                }
                else
                {
                    return 0; // Servicio no encontrado
                }
            }
        }

        public static int eliminar(int id)
        {
            using (var context = new GimnasioEntities())
            {
                var servicio = context.Servicio.Find(id); // <--- ¿Aquí encuentra el entrendor?
                if (servicio != null)
                {
                    context.Servicio.Remove(servicio);
                    return context.SaveChanges();
                }
                return 0;
            }
        }
        public static Servicio obtenerUno(int id)
        {
            using (var context = new GimnasioEntities())
            {
                return context.Servicio.Find(id);
            }
        }

        public static List<Servicio> listar()
        {
            using (var context = new GimnasioEntities())
            {
                context.Configuration.LazyLoadingEnabled = false; // AGREGA ESTA LÍNEA
                return context.Servicio.ToList();
            }
        }

        public static List<Servicio> listar(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                // Esto busca en la tabla real, sin importar el procedimiento almacenado
                return context.Servicio
                    .Where(u => u.nombre.Contains(parametro) || u.descripcion.Contains(parametro))
                    .ToList();
            }
        }
    }
}