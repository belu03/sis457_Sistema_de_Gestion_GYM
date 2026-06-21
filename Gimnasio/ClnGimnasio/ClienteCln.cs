using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadGimnasio;

namespace ClnGimnasio
{
    public class ClienteCln
    {
        public static int crear(Cliente cliente)
        {
            using (var context = new GimnasioEntities())
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return cliente.id;
            }
        }

        public static int modificar(Cliente cliente)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Cliente.Find(cliente.id);
                if (existente != null)
                {
                    existente.ci = cliente.ci;
                    existente.nombre = cliente.nombre;
                    existente.apellido = cliente.apellido;
                    existente.telefono = cliente.telefono;
                    existente.correo = cliente.correo;
                    existente.usuarioRegistro = cliente.usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Cliente.Find(id);
                if (existente != null)
                {
                    existente.estado = 0;
                    existente.usuarioRegistro = usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int deshabilitar(int id, string usuarioRegistro)
        {
            using (var context = new GimnasioEntities())
            {
                var existente = context.Cliente.Find(id);
                if (existente != null)
                {
                    existente.estado = -1; // -1 = Deshabilitado (bloqueo total)
                    existente.usuarioRegistro = usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static Cliente obtenerUno(int id)
        {
            using (var context = new GimnasioEntities())
            {
                return context.Cliente.Find(id);
            }
        }

        public static List<Cliente> listar()
        {
            using (var context = new GimnasioEntities())
            {
                return context.Cliente
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.apellido)
                    .ToList();
            }
        }

        public static List<Cliente> listarConMembresiaActiva()
        {
            using (var context = new GimnasioEntities())
            {
                var clientes = context.Cliente
                    .Where(c => c.estado == 1)
                    .Where(c => context.Inscripcion.Any(i =>
                        i.id_cliente == c.id &&
                        i.estado == 1 &&
                        i.estado_inscripcion == "Activa"))
                    .OrderBy(c => c.apellido)
                    .ToList();

                return clientes;
            }
        }

        public static List<paClienteListar_Result> listarPa(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.paClienteListar(parametro.Trim()).ToList();
            }
        }

        public static bool ExisteCi(string ci, int idCliente = 0)
        {
            string ciLimpio = ci.Trim();

            using (var contexto = new GimnasioEntities())
            {
                return contexto.Cliente.Any(x => x.ci.Trim() == ciLimpio && x.id != idCliente);
            }
        }

        public static Cliente obtenerInactivoPorCi(string ci)
        {
            using (var contexto = new GimnasioEntities())
            {
                return contexto.Cliente.FirstOrDefault(x => x.ci.Trim() == ci.Trim() && x.estado == 0);
            }
        }

        public static List<Cliente> listarInactivos(string pa)
        {
            using (var contexto = new GimnasioEntities())
            {
                contexto.Configuration.ProxyCreationEnabled = false;

                return contexto.Cliente
                    .Where(x => x.estado <= 0 && (x.nombre.Contains(pa) || x.ci.Contains(pa)))
                    .ToList();
            }
        }

        public static int reactivar(int id, string usuarioRegistro)
        {
            using (var contexto = new GimnasioEntities())
            {
                var existente = contexto.Cliente.Find(id);
                if (existente != null)
                {
                    existente.estado = 1;
                    existente.usuarioRegistro = usuarioRegistro;
                    return contexto.SaveChanges();
                }
                return 0;
            }
        }
    }
}