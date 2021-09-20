using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class ReservationRoomDomainService : IReservationRoomDomain
    {
        private readonly IReservationRoomRepository reservationRoomRepository;
        private readonly IMapper mapper;

        public ReservationRoomDomainService(IReservationRoomRepository reservationRoomRepository, IMapper mapper)
        {
            this.reservationRoomRepository = reservationRoomRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ReservationRoomModel>> GetAllReservesRooms()
        {
            var allReservations = await reservationRoomRepository.GetAllReservationRoom();
            var allRegistersReservesRooms = mapper.Map<IEnumerable<ReservationRoomModel>>(allReservations);

            return allRegistersReservesRooms;
        }
    }
}
