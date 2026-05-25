using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnGimnasio
{
    public class AsistenciaCln
    {
        public static int crear(Asistencia asistencia)
        {
            using (var context = new GimnasioEntities())
            {
                context.Asistencia.Add(asistencia);
                context.SaveChanges();
                return asistencia.id;
            }
        }

        public static int modificar(Asistencia asistencia)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Asistencia.Find(asistencia.id);
                if (existente != null)
                {
                    existente.fecha = asistencia.fecha;
                    existente.estado = asistencia.estado;
                    return context.SaveChanges();

                }
                else
                {
                    return 0; // Asistencia no encontrada
                }
            }
        }

        public static int eliminar(int id)
        {
            using (var context = new GimnasioEntities())
            {
                var asistencia = context.Asistencia.Find(id);
                if (asistencia != null)
                {
                    context.Asistencia.Remove(asistencia);
                    return context.SaveChanges();
                }
                else
                {
                    return 0; // Asistencia no encontrada
                }
            }
        }
        public static Asistencia obtenerUno(int id)
        {
            using (var context = new GimnasioEntities())
            {
                return context.Asistencia.Find(id);
            }
        }

        public static List<Asistencia> listar()
        {
            using (var context = new GimnasioEntities())
            {
                return context.Asistencia.ToList();
            }
        }

        public static List<spAsistenciaListar_Result> listar(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.spAsistenciaListar(parametro.Trim()).ToList();
            }
        }
    }
}
