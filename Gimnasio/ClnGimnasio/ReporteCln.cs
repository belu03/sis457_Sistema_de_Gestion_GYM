using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CadGimnasio;

namespace ClnGimnasio
{
    public class ReporteCln
    {

        public static List<paReporteIngresos_Result> ReporteIngresos(DateTime inicio, DateTime fin)
        {
            using (var context = new GimnasioEntities())
            {
                return context.paReporteIngresos(inicio.Date, fin.Date).ToList();
            }
        }


        public class MembresiaPopularResult
        {
            public int IdMembresia { get; set; }
            public int CantidadVendida { get; set; }
            public decimal TotalIngresos { get; set; }
        }

        public static List<MembresiaPopularResult> ObtenerMembresiasPopulares()
        {
            using (var context = new GimnasioEntities())
            {
                return context.Inscripcion
                    .Where(i => i.estado == 1 && i.estado_inscripcion == "Activa")
                    .GroupBy(i => i.id_membresia)
                    .Select(g => new MembresiaPopularResult
                    {
                        IdMembresia = g.Key,
                        CantidadVendida = g.Count(),
                        TotalIngresos = g.Sum(i => i.monto_pagado)
                    })
                    .OrderByDescending(r => r.CantidadVendida)
                    .ToList();
            }
        }

    
        public class AlertaVencimientoResult
        {
            public int IdCliente { get; set; }
            public int IdMembresia { get; set; }
            public DateTime Vencimiento { get; set; }
            public int DiasRestantes { get; set; }
        }

        public static List<AlertaVencimientoResult> ObtenerAlertaVencimientos(int diasMargen = 7)
        {
            using (var context = new GimnasioEntities())
            {
                DateTime fechaLimite = DateTime.Now.Date.AddDays(diasMargen);
                DateTime hoy = DateTime.Now.Date;

                var vencimientos = context.Inscripcion
                    .Where(i => i.estado == 1 && i.estado_inscripcion == "Activa" && i.fecha_fin >= hoy && i.fecha_fin <= fechaLimite)
                    .ToList(); 

                return vencimientos.Select(i => new AlertaVencimientoResult
                {
                    IdCliente = i.id_cliente,
                    IdMembresia = i.id_membresia,
                    Vencimiento = i.fecha_fin,
                    DiasRestantes = (i.fecha_fin.Date - hoy).Days
                })
                    .OrderBy(r => r.DiasRestantes)
                    .ToList();
            }
        }
    }
}