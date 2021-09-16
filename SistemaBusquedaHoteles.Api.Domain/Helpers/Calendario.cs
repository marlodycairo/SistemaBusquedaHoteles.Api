using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Helpers
{
    public class Calendario
    {
        public List<DateTime> GetCalendario()
        {
            //Obtiene las fechas para el tiempo asignada.
            var fechaInit = new DateTime(2021, 9, 1);
            var fFin = new DateTime(2021, 9, 1).AddYears(2).AddMonths(2).AddDays(31);

            var listadoFechas = new List<DateTime>();

            for (DateTime fechas = fechaInit; fechas < fFin; fechas = fechas.AddDays(1))
            {
                listadoFechas.Add(fechas);
            }

            return listadoFechas.ToList();
        }

        public List<DateTime> GetFechasTemporadaAlta()
        {
            //Fecha inicio temporada alta meses Noviembre 1 hasta Abril 20
            var fInicioAl1 = new DateTime(2021, 11, 1);

            //Temporada Alta es de noviembre hasta abril - Y luego desde el 20 de junio, Julio y agosto.
            DateTime tAlta1 = new DateTime(2021, 11, 1).AddMonths(5).AddDays(20);

            //Fecha inicio temporada alta meses Junio 21 hasta Agosto 30
            var fInicioAl2 = new DateTime(2021, 6, 21);
            //desde el 21 de junio, Julio hasta agosto 30.
            DateTime tAlta2 = new DateTime(2021, 6, 21).AddMonths(2).AddDays(10);

            var TAlta = new List<DateTime>();

            var listadoFechas = GetCalendario();

            foreach (DateTime item in listadoFechas)
            {
                for (DateTime fecha = fInicioAl1; fecha < tAlta1; fecha = fecha.AddDays(1))
                {
                    if (item == fecha)
                    {
                        TAlta.Add(item);
                    }
                }

                for (DateTime fecha = fInicioAl2; fecha < tAlta2; fecha = fecha.AddDays(1))
                {
                    if (item == fecha)
                    {
                        TAlta.Add(item);
                    }
                }
            }

            return TAlta;
        }

        public List<DateTime> GetFechasTemporadaBaja()
        {
            //Fecha inicio temporada baja meses Abril 22 hasta 20 de junio
            var fInicioBaj1 = new DateTime(2022, 4, 22);
            //Temporada Baja Abril + Mayo + hasta el 22 de junio +Septiembre a octubre
            DateTime tBaja1 = new DateTime(2022, 4, 22).AddMonths(2).AddDays(30);

            //Fecha inicio temporada baja meses Septiembre 1 hasta Octubre 30
            var fInicioBaj2 = new DateTime(2021, 9, 1);
            //Temporada Baja meses Septiembre - Octubre
            DateTime tBaja2 = new DateTime(2021, 9, 1).AddMonths(1).AddDays(31);

            var TBaja = new List<DateTime>();

            for (DateTime fecha = fInicioBaj1; fecha > tBaja1; fecha = fecha.AddDays(1))
            {
                TBaja.Add(fecha);
            }

            for (DateTime fecha = fInicioBaj2; fecha > tBaja2; fecha = fecha.AddDays(1))
            {
                TBaja.Add(fecha);
            }

            return TBaja;
        }
    }
}
