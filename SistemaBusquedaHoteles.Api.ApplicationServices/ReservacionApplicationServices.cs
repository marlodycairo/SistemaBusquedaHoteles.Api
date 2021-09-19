using AutoMapper;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.ApplicationServices
{
    public class ReservacionApplicationServices : IReservacionApplication
    {
        private readonly IReservacionDomain reservacionDomain;
        private readonly IMapper mapper;

        public ReservacionApplicationServices(IReservacionDomain reservacionDomain, IMapper mapper)
        {
            this.reservacionDomain = reservacionDomain;
            this.mapper = mapper;
        }

        public async Task<Reservations> CreateReservation(Reservations reservacion)
        {
            var objReservacion = mapper.Map<Reservation>(reservacion);
            var reservaciones = await reservacionDomain.CreateReservacion(objReservacion);

            return reservaciones;
        }

        public async Task DeleteReservacion(int id)
        {
            await reservacionDomain.DeleteReservacion(id);
        }

        public async Task<Reservations> GetReservationById(int id)
        {
            return await reservacionDomain.GetReservationById(id);
        }

        public async Task<IEnumerable<Reservations>> GetReservaciones(ReservacionQueryFilter filter)
        {
            return await reservacionDomain.GetReservaciones(filter);
        }

        public async Task<Reservation> UpdateReservation(Reservations reservacion)
        {
            return await reservacionDomain.UpdateReservacion(reservacion);
        }
    }
}
