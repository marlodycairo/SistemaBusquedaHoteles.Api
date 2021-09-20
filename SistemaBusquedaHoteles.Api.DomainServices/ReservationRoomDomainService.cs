using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Helpers.Constants;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
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
        private readonly IHabitacionesRepository habitacionesRepo;

        public ReservationRoomDomainService(IReservationRoomRepository reservationRoomRepository, IMapper mapper, IHabitacionesRepository habitacionesRepo)
        {
            this.reservationRoomRepository = reservationRoomRepository;
            this.mapper = mapper;
            this.habitacionesRepo = habitacionesRepo;
        }

        public async Task<IEnumerable<ReservationRoomModel>> GetAllReservesRooms(ReservacionQueryFilter filter)
        {
            var allReservations = await reservationRoomRepository.GetAllReservationRoom();
            var allRegistersReservesRooms = mapper.Map<IEnumerable<ReservationRoomModel>>(allReservations);

            var rooms = await habitacionesRepo.GetAll();

            var reservationRooms = new List<ReservationRoomModel>();

            if (filter.Ciudad != 0)
            {
                allRegistersReservesRooms = allRegistersReservesRooms.Where(p => p.ReservationModel.SedeId == filter.Ciudad);
            }

            if (filter.Fecha != null)
            {
                allRegistersReservesRooms = allRegistersReservesRooms.Where(p => p.RoomsModel.Fecha > filter.Fecha).Where(p => p.RoomsModel.Fecha != filter.Fecha);

                reservationRooms.Add(new ReservationRoomModel
                {
                    Response = Constants.fechaNoDisponible
                });
                return reservationRooms.ToList();
            }

            if (filter.TotalPersonas != 0)
            {
                allRegistersReservesRooms = allRegistersReservesRooms.Where(p => p.RoomsModel.Locations.CupoMax > filter.TotalPersonas);
                reservationRooms.Add(new ReservationRoomModel
                {
                    Response = Constants.superaCapacidadMax
                });
            }

            if (filter.SeleccionarTipoHabitacion != 0)
            {

            }

            if (filter.TotalHabitaciones != 0)
            {

            }
            return allRegistersReservesRooms;
        }
    }
}
