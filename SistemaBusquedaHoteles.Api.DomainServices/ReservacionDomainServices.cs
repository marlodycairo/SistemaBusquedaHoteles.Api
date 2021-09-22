using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
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

        public async Task<ReservationsModel> CreateReservacion(Reservation reservacion)
        {
            await reservacionRepository.CreateReservation(reservacion);
            ReservationsModel reserva = mapper.Map<ReservationsModel>(reservacion);
            return reserva;
        }

        public async Task DeleteReservacion(int id)
        {
            await reservacionRepository.DeleteReservation(id);
        }

        public async Task<ReservationsModel> GetReservationById(int id)
        {
            Reservation reservas = await reservacionRepository.GetReservationById(id);

            ReservationsModel result = mapper.Map<ReservationsModel>(reservas);

            return result;
        }

        public async Task<IEnumerable<ReservationsModel>> GetReservaciones(ReservacionQueryFilter filter)
        {
            Task<IEnumerable<Reservation>> reservaciones = reservacionRepository.GetAllReservations();
            IEnumerable<ReservationsModel> result = mapper.Map<IEnumerable<Domain.Models.ReservationsModel>>(reservaciones);

            if (filter.Ciudad != 0)
            {

            }

            if (filter.Fecha != null)
            {

            }

            if (filter.TotalPersonas != 0)
            {

            }

            if (filter.TotalHabitaciones != 0)
            {

            }

            if (filter.SeleccionarTipoHabitacion != 0)
            {

            }
            return result;
        }

        public async Task<Reservation> UpdateReservacion(ReservationsModel reservacion)
        {
            Reservation reservas = mapper.Map<Reservation>(reservacion);

            Reservation reservationUpdate = await reservacionRepository.UpdateReservation(reservas);

            return reservationUpdate;
        }

        public double TarifasDisponibles(DateTime? fecha, int tipoHabitacion)
        {
            double valorHabitacion = 0;
            //Fecha inicio temporada baja meses Septiembre 1 hasta Octubre 30
            DateTime fInicioBaj2 = new DateTime(2021, 9, 1);

            //Temporada Baja meses Septiembre - Octubre
            DateTime tBaja2 = new DateTime(2021, 9, 1).AddMonths(1).AddDays(31);

            //Fecha inicio temporada baja meses Abril 22 hasta 20 de junio
            DateTime fInicioBaj1 = new DateTime(2022, 4, 21);

            //Temporada Baja Abril + Mayo + hasta el 22 de junio +Septiembre a octubre
            DateTime tBaja1 = new DateTime(2022, 4, 22).AddMonths(2);

            //IEnumerable<ReservationsModel> query = (from p in listaHabitaciones
            //                                   join reservas in result on p.RoomTypeModel.Nombre equals reservas.RoomTypesModel.Nombre
            //                                   where p.TipoId == tipoHabitacion
            //                                   select reservas);

            //foreach (ReservationsModel item in query)
            //{
            //    if (fecha >= fInicioBaj2 && fecha <= tBaja2 || fecha >= fInicioBaj1 && fecha <= tBaja1)
            //    {
            //        valorHabitacion = item.RateModel.Valor;
            //    }
            //    else
            //    {
            //        item.RateModel.Temporada = Constants.confirmartemporada;
            //    }
            //}
            return valorHabitacion;
        }
    }
}
