using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadGimnasio;

namespace ClnGimnasio
{
    public class MembresiaCln
    {
        public static int crear(Membresia membresia)
        {
            using (var context = new GimnasioEntities())
            {
                context.Membresia.Add(membresia);
                context.SaveChanges();
                return membresia.id;
            }
        }

        public static int modificar(Membresia membresia)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Membresia.Find(membresia.id);
                if (existente != null)
                {
                    existente.tipo = membresia.tipo;
                    existente.precio = membresia.precio;
                    existente.duracion_dias = membresia.duracion_dias;
                    existente.usuarioRegistro = membresia.usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Membresia.Find(id);
                if (existente != null)
                {
                    existente.estado = 0;
                    existente.usuarioRegistro = usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static Membresia obtenerUno(int id)
        {
            using (var context = new GimnasioEntities())
            {
                return context.Membresia.Find(id);
            }
        }

        public static List<Membresia> listar()
        {
            using (var context = new GimnasioEntities())
            {
                return context.Membresia
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.tipo)
                    .ToList();
            }
        }

        public static List<paMembresiaListar_Result> listarPa(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.paMembresiaListar(parametro.Trim()).ToList();
            }
        }
    }
}
