using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    context.Horario.Remove(horario);
                    return context.SaveChanges();
                }
                else
                {
                    return 0; // Horario no encontrado
                }
            }
        }
        public static Horario obtenerUno(int id)
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
                return context.Horario.ToList();
            }
        }

        public static List<spHorarioListar_Result> listar(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.spHorarioListar(parametro.Trim()).ToList();
            }
        }
    }
}
