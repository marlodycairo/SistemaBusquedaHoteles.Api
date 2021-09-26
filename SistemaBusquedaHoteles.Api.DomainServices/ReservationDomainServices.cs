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
    public class ReservationDomainServices : IReservationDomain
    {
        private readonly IReservationRepository reservacionRepository;
        private readonly IMapper mapper;

        public ReservationDomainServices(IReservationRepository reservacionRepository, IMapper mapper)
        {
            this.reservacionRepository = reservacionRepository;
            this.mapper = mapper;
        }

        public async Task<ReservationsModel> CreateReservacion(Reservation reservacion)
        {
            await reservacionRepository.CreateReservation(reservacion);
            
            var reserva = mapper.Map<ReservationsModel>(reservacion);
            
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

        public async Task<IEnumerable<ReservationsModel>> GetReservaciones(ReservacionQueryFilterModel filter)
        {
            var reservaciones = await reservacionRepository.GetAllReservations();
            
            var result = mapper.Map<IEnumerable<Domain.Models.ReservationsModel>>(reservaciones);

            return result;
        }

        public async Task<Reservation> UpdateReservacion(ReservationsModel reservacion)
        {
            Reservation reservas = mapper.Map<Reservation>(reservacion);

            Reservation reservationUpdate = await reservacionRepository.UpdateReservation(reservas);

            return reservationUpdate;
        }
    }
}
