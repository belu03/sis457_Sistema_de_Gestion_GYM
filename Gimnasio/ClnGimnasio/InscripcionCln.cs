using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadGimnasio;


namespace ClnGimnasio
{
    public class InscripcionCln
    {
        public static int crear(Inscripcion inscripcion)
        {
            using (var context = new GimnasioEntities())
            {
                context.Inscripcion.Add(inscripcion);
                context.SaveChanges();
                return inscripcion.id;
            }
        }

        public static int anular(int id, string usuarioRegistro)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Inscripcion.Find(id);
                if (existente != null)
                {
                    existente.estado_inscripcion = "Anulada";
                    existente.estado = 0;
                    existente.usuarioRegistro = usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static List<paInscripcionListar_Result> listarPa(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.paInscripcionListar(parametro.Trim()).ToList();
            }
        }
    }
}
