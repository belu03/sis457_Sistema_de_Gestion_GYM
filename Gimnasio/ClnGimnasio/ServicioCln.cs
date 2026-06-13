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
                    existente.capacidad_maxima = servicio.capacidad_maxima;
                    existente.usuarioRegistro = servicio.usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Servicio.Find(id);
                if (existente != null)
                {
                    existente.estado = 0;
                    existente.usuarioRegistro = usuarioRegistro;
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
                return context.Servicio
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.nombre)
                    .ToList();
            }
        }

        public static List<paServicioListar_Result> listarPa(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.paServicioListar(parametro.Trim()).ToList();
            }
        }
    }
}
