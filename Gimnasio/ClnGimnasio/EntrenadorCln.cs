using CadGimnasio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnGimnasio
{
    public class EntrenadorCln
    {
        public static int crear(Entrenador entrenador)
        {
            using (var context = new GimnasioEntities())
            {
                context.Entrenador.Add(entrenador);
                context.SaveChanges();
                return entrenador.id;
            }
        }

        public static int modificar(Entrenador entrenador)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Entrenador.Find(entrenador.id);
                if (existente != null)
                {
                    existente.nombre = entrenador.nombre;
                    existente.apellido = entrenador.apellido;
                    existente.telefono = entrenador.telefono;
                    existente.especialidad = entrenador.especialidad;
                    existente.usuarioRegistro = entrenador.usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Entrenador.Find(id);
                if (existente != null)
                {
                    existente.estado = 0; 
                    existente.usuarioRegistro = usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static Entrenador obtenerUno(int id)
        {
            using (var context = new GimnasioEntities())
            {
                return context.Entrenador.Find(id);
            }
        }

        public static List<Entrenador> listar()
        {
            using (var context = new GimnasioEntities())
            {
                return context.Entrenador
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.apellido)
                    .ToList();
            }
        }

        public static List<paEntrenadorListar_Result> listarPa(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.paEntrenadorListar(parametro.Trim()).ToList();
            }
        }
    }
}
