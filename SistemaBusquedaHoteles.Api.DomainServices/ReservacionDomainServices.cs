using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class ReservacionDomainServices : IReservacionDomain
    {
        private readonly IReservacionRepository reservacionRepository;
        private readonly IMapper mapper;

        public ReservacionDomainServices(IReservacionRepository reservacionRepository, IMapper mapper)
        {
            this.reservacionRepository = reservacionRepository;
            this.mapper = mapper;
        }

        public int CalcularHabitacionesDisponibles(string ciudad)
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            int totalHabitacionesDisponibles = 0;
            int totalOcupadas = 0;

            foreach (var item in result)
            {
                if (item.SedesModel.Ciudad.ToLower() == ciudad.ToLower())
                {
                    totalOcupadas++;
                }
            }

            var totalPorSede = (from p in result
                                    where p.HabitacionesModel.Sedes.Ciudad.ToLower() == ciudad.ToLower()
                                   select p.SedesModel.TotalHabitaciones).FirstOrDefault();


            totalHabitacionesDisponibles = totalPorSede - totalOcupadas;

            return totalHabitacionesDisponibles;
        }

        public double CalcularTarifa()
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            return 0;
        }

        public DateTime CalcularTemporada()
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            //Fecha inicio temporada alta meses Noviembre 1 hasta Abril 20
            var fInicioAl1 = new DateTime(2021, 11, 1);

            //Temporada Alta es desde el 20 de junio, Julio y agosto.
            DateTime tAlta1 = new DateTime(2021, 11, 1).AddMonths(5).AddDays(20);

            //Fecha inicio temporada alta meses Junio 21 hasta Agosto 30
            var fInicioAl2 = new DateTime(2021, 6, 21);

            //desde el 21 de junio, Julio hasta agosto 30.
            DateTime tAlta2 = new DateTime(2021, 6, 21).AddMonths(2).AddDays(10);


            //Fecha inicio temporada baja meses Abril 22 hasta 20 de junio
            var fInicioBaj1 = new DateTime(2022, 4, 22);

            //Temporada Baja Abril + Mayo + hasta el 22 de junio +Septiembre a octubre
            DateTime tBaja1 = new DateTime(2022, 4, 22).AddMonths(2).AddDays(30);

            //Fecha inicio temporada baja meses Septiembre 1 hasta Octubre 30
            var fInicioBaj2 = new DateTime(2021, 9, 1);

            //Temporada Baja meses Septiembre - Octubre
            DateTime tBaja2 = new DateTime(2021, 9, 1).AddMonths(1).AddDays(31);

            return DateTime.Now;
        }

        public double CalcularValorAPagar()
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            return 0;
        }



        public ReservacionViewModel CreateReservacion(Reservacion reservacion)
        {
            reservacionRepository.CreateReservacion(reservacion);

            var reserva = mapper.Map<ReservacionViewModel>(reservacion);
            return reserva;
        }

        public void DeleteReservacion(int id)
        {
            reservacionRepository.DeleteReservacion(id);
        }

        public ReservacionViewModel GetReservaById(int id)
        {
            var reservas = reservacionRepository.GetReservaById(id);

            var result = mapper.Map<ReservacionViewModel>(reservas);

            return result;
        }

        public IEnumerable<ReservacionViewModel> GetReservaciones(ReservacionQueryFilter filter)
        {
            var reservas = reservacionRepository.GetReservaciones();

            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservas);

            ReservacionViewModel testModel = new ReservacionViewModel();

            List<ReservacionViewModel> testList = new List<ReservacionViewModel>();

            if (filter.Ciudad != null)
            {
                result = result.Where(p => p.SedesModel.Ciudad.ToLower() == filter.Ciudad.ToLower());
            }

            if (filter.Fecha != null)
            {
                result = result.Where(p => p.Fecha.ToShortDateString() == filter.Fecha?.ToShortDateString());
            }

            if (filter.TotalPersonas != 0)
            {
                result = result.Where(p => p.SedesModel.CupoMax <= filter.TotalPersonas);
            }

            if (filter.TotalHabitaciones != 0)
            {
                var reservaciones = new ReservacionViewModel();

                var reserva = new ReservacionDomainServices(reservacionRepository, mapper);

                var test = reserva.CalcularHabitacionesDisponibles(filter.Ciudad.ToLower());
                


                result = result.Where(p => p.TotalHabitaciones == filter.TotalHabitaciones);
            }

            return result;
        }

        public ReservacionViewModel UpdateReservacion(ReservacionViewModel reservacion)
        {
            var reservas = mapper.Map<Reservacion>(reservacion);

            reservacionRepository.UpdateReservacion(reservas);

            return reservacion;
        }

        
        
        
        public DateTime ValidarFechasDisponibles()
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            return DateTime.Today;
        }
    }
}
