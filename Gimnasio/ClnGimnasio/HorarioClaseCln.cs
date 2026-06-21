using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadGimnasio;

namespace ClnGimnasio
{
    public class HorarioClaseCln
    {
        public static int crear(HorarioClase horario)
        {
            using (var context = new GimnasioEntities())
            {
                context.HorarioClase.Add(horario);
                context.SaveChanges();
                return horario.id;
            }
        }

        public static int modificar(HorarioClase horario)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.HorarioClase.Find(horario.id);
                if (existente != null)
                {
                    existente.id_servicio = horario.id_servicio;
                    existente.id_entrenador = horario.id_entrenador;
                    existente.dia_semana = horario.dia_semana;
                    existente.hora_inicio = horario.hora_inicio;
                    existente.hora_fin = horario.hora_fin;
                    existente.usuarioRegistro = horario.usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.HorarioClase.Find(id);
                if (existente != null)
                {
                    existente.estado = 0;
                    existente.usuarioRegistro = usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static HorarioClase obtenerUno(int id)
        {
            using (var context = new GimnasioEntities())
            {
                return context.HorarioClase.Find(id);
            }
        }

        public static List<HorarioClase> listar()
        {
            using (var context = new GimnasioEntities())
            {
                return context.HorarioClase.Where(x => x.estado == 1).ToList();
            }
        }

        public static List<paHorarioClaseListar_Result> listarPa(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.paHorarioClaseListar(parametro.Trim()).ToList();
            }
        }
        public static bool ExisteCruceHorario(
        int idEntrenador,
        string dia,
        TimeSpan horaInicio,
        TimeSpan horaFin,
        int idHorario = 0)
        {
        using (var context = new GimnasioEntities())
                {
                    return context.HorarioClase.Any(x =>
                    x.estado == 1 &&
                    x.id_entrenador == idEntrenador &&
                    x.dia_semana == dia &&
                    x.id != idHorario &&
                    horaInicio < x.hora_fin &&
                    horaFin > x.hora_inicio);
                }
        }
    }
}
