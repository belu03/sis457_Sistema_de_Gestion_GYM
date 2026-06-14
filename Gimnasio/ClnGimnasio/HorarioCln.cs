using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ClnGimnasio
{
    public class HorarioCln
    {
      
        public static int crear(Horario horario)
        {
            using (var context = new GimnasioEntities())
            {
                context.Horario.Add(horario);
                context.SaveChanges();
                return horario.id;
            }
        }

        public static int modificar(Horario horario)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Horario.Find(horario.id);
                if (existente != null)
                {
                    existente.dia = horario.dia;
                    existente.hora_inicio = horario.hora_inicio;
                    existente.hora_fin = horario.hora_fin;
                    existente.id_servicio = horario.id_servicio;
                    existente.id_entrenador = horario.id_entrenador;
                    return context.SaveChanges();

                }
                else
                {
                    return 0; // Horario no encontrado
                }
            }
        }

        public static int eliminar(int id)
        {
            using (var context = new GimnasioEntities())
            {
                var horario = context.Horario.Find(id);
                if (horario != null)
                {
                    // Verificamos si tiene reservas antes de intentar borrar
                    if (horario.Reserva.Count > 0)
                    {
                        throw new Exception("No se puede eliminar el horario porque tiene reservas asociadas.");
                    }

                    context.Horario.Remove(horario);
                    return context.SaveChanges();
                }
                return 0;
            }
        }
        public static Horario obtenerUno(int id) // <-- ¡NO PONGAS PUNTO Y COMA AQUÍ!
        {
            using (var context = new GimnasioEntities())
            {
                return context.Horario.Find(id);
            }
        }

        public static List<Horario> listar()
        {
            using (var context = new GimnasioEntities())
            {
                // 1. DESHABILITAR LA CARGA PEREZOSA (CRÍTICO)
                context.Configuration.LazyLoadingEnabled = false;

                // 2. Traer todo lo necesario de una sola vez
                return context.Horario
                    .Include(h => h.Servicio)
                    .Include(h => h.Entrenador)
                    .ToList();
            }
        }


        public static List<Horario> listar(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                // Esto busca en la tabla real, sin importar el procedimiento almacenado
                return context.Horario
                    .Where(u => u.dia.Contains(parametro))
                    .ToList();
            }
        }
    }
}