using AutoMapper;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.ApplicationServices
{
    public class ReservationRoomApplicationService : IReservationRoomApplication
    {
        private readonly IReservationRoomDomain reservationRoomDomain;

        public ReservationRoomApplicationService(IReservationRoomDomain reservationRoomDomain)
        {
            this.reservationRoomDomain = reservationRoomDomain;
        }

        public async Task<IEnumerable<ReservationRoomModel>> GetAllReservesRooms(ReservacionQueryFilter filter)
        {
            return await reservationRoomDomain.GetAllReservesRooms(filter);
        }
    }
}
