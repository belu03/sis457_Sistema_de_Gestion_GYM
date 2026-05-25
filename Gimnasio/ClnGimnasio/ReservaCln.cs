using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnGimnasio
{
    public class ReservaCln
    {
        public static int crear(Reserva reserva)
        {
            using (var context = new GimnasioEntities())
            {
                context.Reserva.Add(reserva);
                context.SaveChanges();
                return reserva.id;
            }
        }

        public static int modificar(Reserva reserva)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Reserva.Find(reserva.id);
                if (existente != null)
                {
                    existente.fecha = reserva.fecha;
                    existente.estado = reserva.estado;
                    return context.SaveChanges();

                }
                else
                {
                    return 0; // Reserva no encontrada
                }
            }
        }

        public static int eliminar(int id)
        {
            using (var context = new GimnasioEntities())
            {
                var reserva = context.Reserva.Find(id);
                if (reserva != null)
                {
                    context.Reserva.Remove(reserva);
                    return context.SaveChanges();
                }
                else
                {
                    return 0; // Reserva no encontrada
                }
            }
        }
        public static Reserva obtenerUno(int id)
        {
            using (var context = new GimnasioEntities())
            {
                return context.Reserva.Find(id);
            }
        }

        public static List<Reserva> listar()
        {
            using (var context = new GimnasioEntities())
            {
                return context.Reserva.ToList();
            }
        }

        public static List<spReservaListar_Result> listar(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.spReservaListar(parametro.Trim()).ToList();
            }
        }
    }
}
