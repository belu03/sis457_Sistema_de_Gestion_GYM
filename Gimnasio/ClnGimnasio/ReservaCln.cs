using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CadGimnasio;
using System.Threading.Tasks;

namespace ClnGimnasio
{
    public class ReservaCln
    {
        public static int crear(Reserva reserva)
        {
            using (var context = new GimnasioEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var horario = context.HorarioClase.Find(reserva.id_horarioclase);
                        var servicio = context.Servicio.Find(horario.id_servicio);

                        int cuposActuales = horario.cupos_reservados;

                        if (cuposActuales >= servicio.capacidad_maxima)
                        {
                            throw new Exception("La clase ha alcanzado su capacidad máxima.");
                        }

                        horario.cupos_reservados = cuposActuales + 1;
                        context.Reserva.Add(reserva);

                        context.SaveChanges();
                        transaction.Commit();
                        return reserva.id;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public static int modificar(Reserva reserva)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Reserva.Find(reserva.id);
                if (existente != null)
                {
                    existente.id_cliente = reserva.id_cliente;
                    existente.id_horarioclase = reserva.id_horarioclase;
                    existente.fecha_reserva = reserva.fecha_reserva;
                    existente.asistio = reserva.asistio;
                    existente.estado_reserva = reserva.estado_reserva;
                    existente.usuarioRegistro = reserva.usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new GimnasioEntities())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var reserva = context.Reserva.Find(id);
                        if (reserva != null && reserva.estado != 0)
                        {
                            reserva.estado = 0;
                            reserva.estado_reserva = "Anulada";
                            reserva.usuarioRegistro = usuarioRegistro;

                            var horario = context.HorarioClase.Find(reserva.id_horarioclase);
                            if (horario != null && horario.cupos_reservados > 0)
                            {
                                horario.cupos_reservados -= 1;
                            }

                            context.SaveChanges();
                            transaction.Commit();
                            return 1;
                        }
                        return 0;
                    }
                    catch (System.Exception)
                    {
                        transaction.Rollback();
                        return 0;
                    }
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

        public static List<paReservaListar_Result> listarPa(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.paReservaListar(parametro.Trim()).Where(x => x.estado == 1).ToList();
            }
        }

        public static bool ExisteReserva(int idCliente, int idHorario, DateTime fecha)
        {
            using (var context = new GimnasioEntities())
            {
                return context.Reserva.Any(r =>
                    r.estado == 1 &&
                    r.id_cliente == idCliente &&
                    r.id_horarioclase == idHorario &&
                    r.fecha_reserva == fecha);
            }
        }
    }
}