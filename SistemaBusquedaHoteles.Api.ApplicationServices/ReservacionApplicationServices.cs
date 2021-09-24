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
    public class ReservacionApplicationServices : IReservationApplication
    {
        private readonly IReservationDomain reservacionDomain;
        private readonly IMapper mapper;

        public ReservacionApplicationServices(IReservationDomain reservacionDomain, IMapper mapper)
        {
            this.reservacionDomain = reservacionDomain;
            this.mapper = mapper;
        }

        public async Task<ReservationsModel> CreateReservation(ReservationsModel reservacion)
        {
            var objReservacion = mapper.Map<Reservation>(reservacion);
            var reservaciones = await reservacionDomain.CreateReservacion(objReservacion);

            return reservaciones;
        }

        public async Task DeleteReservacion(int id)
        {
            await reservacionDomain.DeleteReservacion(id);
        }

        public async Task<ReservationsModel> GetReservationById(int id)
        {
            return await reservacionDomain.GetReservationById(id);
        }

        public async Task<IEnumerable<ReservationsModel>> GetReservaciones(ReservacionQueryFilterModel filter)
        {
            return await reservacionDomain.GetReservaciones(filter);
        }

        public async Task<Reservation> UpdateReservation(ReservationsModel reservacion)
        {
            return await reservacionDomain.UpdateReservacion(reservacion);
        }
    }
}
