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
        private readonly IHabitacionesDomain habitacionesDomain;
        private readonly IHabitacionesRepository habitacionesRepository;
        private readonly IReservacionRepository reservacionRepository;

        public Calendario(IHabitacionesDomain habitacionesDomain, 
            IHabitacionesRepository habitacionesRepository, IReservacionRepository reservacionRepository)
        {
            this.habitacionesDomain = habitacionesDomain;
            this.habitacionesRepository = habitacionesRepository;
            this.reservacionRepository = reservacionRepository;
        }

        public List<DateTime> GetCalendario(DateTime buscar)
        {
            //Obtiene las fechas para un año según la fecha asignada.
            var fInicial = new DateTime(2021, 9, 1);
            var fFin = new DateTime(2021, 9, 1).AddYears(1);

            var listaFechas = new List<DateTime>();

            for (DateTime fechas = fInicial; fechas < fFin; fechas = fechas.AddDays(1))
            {
                listaFechas.Add(fechas);
            }

            var prueba = from p in listaFechas
                         select p;

            var objHabitaciones = habitacionesRepository.GetAll().ToList();
            var objReservaciones = reservacionRepository.GetReservaciones().ToList();

            //var query = from h in objHabitaciones
            //            join r in objReservaciones
            //            on h.reservaId equals r.Id
            //            select r.Fecha;

            //Listado de fechas ocupadas de la entidad Habitaciones
            var query = from p in objHabitaciones
                        //where p.Fecha == buscar
                        select p.Fecha;

            List<DateTime> lst = new List<DateTime>();


            //Comprueba si la fecha solicitada ya existe
            foreach (var item in query)
            {
                if (!Equals(buscar, item))
                {
                    lst.Add(item);
                }
            }

            string message = "Fecha no disponible.";

            //var buscarString = Convert.ToString(buscar);

            //buscard = null;
           
            ////Fechas
            //if (!string.IsNullOrEmpty(Convert.ToString(buscarString)))
            //{
            //    foreach (string item in buscarString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            //    {
            //        objReservaciones = objReservaciones.Where(p => p.Fecha.ToShortDateString().Contains(item)).ToList();
            //    }
            //}

            ////Fecha inicio temporada alta meses Noviembre 1 hasta Abril 20
            //var fInicioAl1 = new DateTime(2021, 11, 1);
            ////Temporada Alta es de noviembre hasta abril - Y luego desde el 20 de junio, Julio y agosto.
            //DateTime tAlta1 = new DateTime(2021, 11, 1).AddMonths(5).AddDays(20);

            ////Fecha inicio temporada alta meses Junio 21 hasta Agosto 30
            //var fInicioAl2 = new DateTime(2021, 6, 21);
            ////desde el 21 de junio, Julio hasta agosto 30.
            //DateTime tAlta2 = new DateTime(2021, 6, 21).AddMonths(2).AddDays(9);

            ////Fecha inicio temporada baja meses Abril 22 hasta 20 de junio
            //var fInicioBaj1 = new DateTime(2022, 4, 22);
            ////Temporada Baja Abril + Mayo + hasta el 22 de junio +Septiembre a octubre
            //DateTime tBaja1 = new DateTime(2021, 4, 22).AddMonths(2);

            ////Fecha inicio temporada baja meses Septiembre 1 hasta Octubre 30
            //var fInicioBaj2 = new DateTime(2022, 9, 1);
            ////Temporada Baja meses Septiembre - Octubre
            //DateTime tBaja2 = new DateTime(2021, 9, 1).AddMonths(1).AddDays(30);

            //var fechasDispoAlta = new List<DateTime>();
            //var fechasDispoBaja = new List<DateTime>();

            //for (DateTime fecha = fInicioAl1; fecha <= tAlta1; fecha = fecha.AddDays(1))
            //{
            //    fechasDispoAlta.Add(fecha);
            //}

            ////Halla el rango de fechas temporadas Alta y Baja
            //if (fInicioAl1 <= tAlta1)
            //{                
            //}
            //if (fInicioAl2 <= tAlta2)
            //{
            //    for (DateTime fecha = fInicioAl2; fecha < tAlta2; fecha = fecha.AddDays(1))
            //    {
            //        fechasDispoAlta.Add(fecha);
            //    }
            //}
            ////return fechasDispoAlta.ToList();            

            //return prueba.ToList();
            return lst.ToList();
        }

        public string ValidarTemporada()
        {
            return "definir si es alta o baja";
        }
    }
}
