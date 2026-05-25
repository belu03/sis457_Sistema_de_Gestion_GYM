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
                    existente.telefono = entrenador.telefono;
                    existente.especialidad = entrenador.especialidad;
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
                var entrenador = context.Entrenador.Find(id);
                if (entrenador != null)
                {
                    context.Entrenador.Remove(entrenador);
                    return context.SaveChanges();
                }
                else
                {
                    return 0; // Entrenador no encontrado
                }
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
                return context.Entrenador.ToList();
            }
        }

        public static List<spEntrenadorListar_Result> listar(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.spEntrenadorListar(parametro.Trim()).ToList();
            }
        }
    }
}
