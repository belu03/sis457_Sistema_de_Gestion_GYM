using CadGimnasio;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ClnGimnasio
{
    public class Repositorio<T> where T : class
    {
        public static T Crear(T entidad)
        {
            using (var db = new GimnasioEntities())
            {
                db.Set<T>().Add(entidad);
                db.SaveChanges();
                return entidad;
            }
        }

        public static bool Modificar(T entidad)
        {
            using (var db = new GimnasioEntities())
            {
                db.Entry(entidad).State = EntityState.Modified;
                return db.SaveChanges() > 0;
            }
        }

        public static T ObtenerUno(int id)
        {
            using (var db = new GimnasioEntities())
            {
                return db.Set<T>().Find(id);
            }
        }

        public static List<T> Listar()
        {
            using (var db = new GimnasioEntities())
            {
                return db.Set<T>().ToList();
            }
        }
    }

}