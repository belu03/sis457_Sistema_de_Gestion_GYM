using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    existente.duracion = membresia.duracion;
                    return context.SaveChanges();

                }
                else
                {
                    return 0; // Membresia no encontrada
                }
            }
        }

        public static int eliminar(int id)
        {
            using (var context = new GimnasioEntities())
            {
                var membresia = context.Membresia.Find(id);
                if (membresia != null)
                {
                    context.Membresia.Remove(membresia);
                    return context.SaveChanges();
                }
                else
                {
                    return 0; // Membresia no encontrada
                }
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
                return context.Membresia.ToList();
            }
        }

        public static List<spMembresiaListar_Result> listar(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.spMembresiaListar(parametro.Trim()).ToList();
            }
        }
    }
}
