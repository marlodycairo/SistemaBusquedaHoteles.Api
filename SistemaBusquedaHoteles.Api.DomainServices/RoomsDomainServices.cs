using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Helpers;
using SistemaBusquedaHoteles.Api.Domain.Helpers.Constants;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class RoomsDomainServices : IRoomsDomain
    {
        private readonly IRoomsRepository habitacionesRepository;
        private readonly IMapper mapper;
        private readonly ILocationRepository sedesRepository;
        private readonly IRoomTypesRepository alojamientoRepository;
        private readonly IReservationRepository reservacionRepository;
        private readonly IRatesRepository tarifasRepository;

        public RoomsDomainServices(IRoomsRepository habitacionesRepository, IMapper mapper, 
            ILocationRepository sedesRepository, IRoomTypesRepository alojamientoRepository,
            IReservationRepository reservacionRepository, IRatesRepository tarifasRepository)
        {
            this.habitacionesRepository = habitacionesRepository;
            this.mapper = mapper;
            this.sedesRepository = sedesRepository;
            this.alojamientoRepository = alojamientoRepository;
            this.reservacionRepository = reservacionRepository;
            this.tarifasRepository = tarifasRepository;
        }

        public async Task<RoomModel> Create(Rooms room)
        {
            await habitacionesRepository.Create(room);

            var roomCreate = mapper.Map<RoomModel>(room);

            return roomCreate;
        }

        public async Task Delete(int id)
        {
            await habitacionesRepository.Delete(id);
        }

        public async Task<IEnumerable<RoomModel>> GetAll(HabitacionesQueryFilterModel filter)
        {
            var rooms = await habitacionesRepository.GetAll();
            var allRooms = mapper.Map<IEnumerable<RoomModel>>(rooms);

            var locations = await sedesRepository.GetSedes();
            var allLocation = mapper.Map<IEnumerable<LocationsModel>>(locations);

            var roomType = await alojamientoRepository.GetAlojamientos();
            var allTypes = mapper.Map<IEnumerable<RoomTypeModel>>(roomType);

            var reservation = await reservacionRepository.GetAllReservations();
            var allReserves = mapper.Map<IEnumerable<ReservationsModel>>(reservation);

            var rates = await tarifasRepository.GetTarifas();
            var allRates = mapper.Map<IEnumerable<RatesModel>>(rates);

            var roomList = new List<RoomModel>();

            var typesList = new List<RoomTypeModel>();

            if (filter.Ciudad != 0)
            {
                allRooms = allRooms.Where(p => p.SedeId == filter.Ciudad);
            }

            if (filter.Fecha != null)
            {
                allRooms = allRooms.Where(p => p.Fecha >= filter.Fecha || p.Fecha <= filter.Fecha).Where(p => p.Estado == Constants.message);
            }

            if (filter.CantidadPersonas != 0)
            {
                var roomLocation = from p in allRooms
                                   join loc in allLocation
                                   on p.SedeId equals loc.Id
                                   select loc;

                foreach (var item in roomLocation)
                {
                    if (filter.CantidadPersonas > item.CupoMax)
                    {
                        roomList.Add(new RoomModel
                        {
                            Response = Constants.superaCapacidadMax
                        });

                        return roomList.ToList();
                    }
                    allRooms = allRooms.Where(p => p.Fecha >= filter.Fecha).Where(p => p.Estado == Constants.message);
                }
            }

            if (filter.Tipo != 0)
            {
                var constants = new Constants();

                var roomTypes = allRooms
                    .Join(allTypes,
                    room => room.TipoId,
                    type => type.Id,
                    (room, type) => new
                    {
                        room, type
                    }).Join(allRates,
                    type => type.room.TipoId,
                    rate => rate.TipoAlojamientoId,
                    (type, rate) => new
                    {
                        type, rate
                    }).Where(p => p.rate.TipoAlojamientoId == filter.Tipo);

                foreach (var item in roomTypes)
                {
                    if (item.type.room.Estado == Constants.message)
                    {
                        if ((filter.Fecha < item.type.room.Fecha && filter.Fecha < constants.finTemporadaBaja) && (item.rate.Temporada == Constants.temporadaB))
                        {
                            if (filter.Tipo == item.type.room.TipoId)
                            {
                                roomList.Add(new RoomModel { Fecha = filter.Fecha, TipoId = filter.Tipo, Estado = Constants.message, PrecioHabitacion = item.rate.Valor });
                            }
                        }
                        else if ((filter.Fecha < item.type.room.Fecha && filter.Fecha < constants.finTemporadaAlta) && (item.rate.Temporada == Constants.temporadaA))
                        {
                            if (filter.Tipo == item.type.room.TipoId)
                            {
                                roomList.Add(new RoomModel { Fecha = filter.Fecha, TipoId = filter.Tipo, Estado = Constants.message, PrecioHabitacion = item.rate.Valor });
                            }
                        }
                    }
                }
                allRooms = roomList.Where(p => p.TipoId == filter.Tipo);

                return allRooms; 
            }

            if (filter.TotalHabitaciones != 0)
            {
                int count = Constants.variableEnCero;
                
                var countRooms = allRooms.Where(p => p.Fecha >= filter.Fecha).Where(p => p.Estado == Constants.message).Count();
                
                if (filter.TotalHabitaciones > countRooms)
                {
                    roomList.Add(new RoomModel 
                    {
                        Response = Constants.valorNoValido
                    });

                    return roomList.ToList();
                }

                foreach (var item in allRooms)
                {
                    roomList.Add(new RoomModel
                    {
                        Fecha = item.Fecha,
                        Estado = item.Estado,
                        SedeId = item.SedeId,
                        TipoId = item.TipoId
                    });
                    count++;
                    
                    if (count == filter.TotalHabitaciones)
                    {
                        allRooms = roomList;
                        count = 0;
                        
                        return allRooms;
                    }
                }
            }

            return allRooms;
        }

        public async Task<RoomModel> GetById(int id)
        {
            var room = await habitacionesRepository.GetById(id);

            var roomById = mapper.Map<RoomModel>(room);

            return roomById;
        }

        public async Task<Rooms> Update(RoomModel room)
        {
            var roomMapper = mapper.Map<Rooms>(room);

            var roomUpdate = await habitacionesRepository.Update(roomMapper);

            return roomUpdate;
        }
    }
}
