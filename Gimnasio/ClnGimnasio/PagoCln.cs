using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnGimnasio
{
    public class PagoCln
    {
        public static int crear(Pago pago)
        {
            using (var context = new GimnasioEntities())
            {
                context.Pago.Add(pago);
                context.SaveChanges();
                return pago.id;
            }
        }

        public static int modificar(Pago pago)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Pago.Find(pago.id);
                if (existente != null)
                {
                    existente.monto = pago.monto;
                    existente.fecha = pago.fecha;
                    existente.metodo_pago = pago.metodo_pago;
                    return context.SaveChanges();

                }
                else
                {
                    return 0; // Pago no encontrado
                }
            }
        }

        public static int eliminar(int id)
        {
            using (var context = new GimnasioEntities())
            {
                var pago = context.Pago.Find(id);
                if (pago != null)
                {
                    context.Pago.Remove(pago);
                    return context.SaveChanges();
                }
                else
                {
                    return 0; // Pago no encontrado
                }
            }
        }
        public static Pago obtenerUno(int id)
        {
            using (var context = new GimnasioEntities())
            {
                return context.Pago.Find(id);
            }
        }

        public static List<Pago> listar()
        {
            using (var context = new GimnasioEntities())
            {
                return context.Pago.ToList();
            }
        }

        public static List<spPagoListar_Result> listar(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.spPagoListar(parametro.Trim()).ToList();
            }
        }
    }
}
