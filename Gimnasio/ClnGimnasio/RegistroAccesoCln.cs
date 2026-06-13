using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadGimnasio;

namespace ClnGimnasio
{
    public class RegistroAccesoCln
    {
        public static int crear(RegistroAcceso acceso)
        {
            using (var context = new GimnasioEntities())
            {
                context.RegistroAcceso.Add(acceso);
                context.SaveChanges();
                return acceso.id;
            }
        }

        public static List<paRegistroAccesoListar_Result> listarPa(string parametro)
        {
            using (var context = new GimnasioEntities())
            {
                return context.paRegistroAccesoListar(parametro.Trim()).ToList();
            }
        }
    }
}
