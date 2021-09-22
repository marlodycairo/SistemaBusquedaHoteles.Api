﻿using AutoMapper;
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
    public class HabitacionesDomainServices : IHabitacionesDomain
    {
        private readonly IHabitacionesRepository habitacionesRepository;
        private readonly IMapper mapper;
        private readonly ISedesRepository sedesRepository;
        private readonly ITipoAlojamientoRepository alojamientoRepository;
        private readonly IReservacionRepository reservacionRepository;
        private readonly ITarifasRepository tarifasRepository;

        public HabitacionesDomainServices(IHabitacionesRepository habitacionesRepository, IMapper mapper, 
            ISedesRepository sedesRepository, ITipoAlojamientoRepository alojamientoRepository,
            IReservacionRepository reservacionRepository, ITarifasRepository tarifasRepository)
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

        public async Task<IEnumerable<RoomModel>> GetAll(ReservacionQueryFilter filter)
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
                allRooms = allRooms.Where(p => p.Fecha >= filter.Fecha).Where(p => p.Estado == Constants.message);
            }

            if (filter.TotalPersonas != 0)
            {
                var roomLocation = from p in allRooms
                                   join loc in allLocation
                                   on p.SedeId equals loc.Id
                                   select loc;

                foreach (var item in roomLocation)
                {
                    if (filter.TotalPersonas > item.CupoMax)
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

            if (filter.SeleccionarTipoHabitacion != 0)
            {
                allTypes = allTypes.Where(p => p.Id == filter.SeleccionarTipoHabitacion);

                var roomTypes = allRooms
                    .Join(allTypes,
                    room => room.TipoId,
                    type => type.Id,
                    (room, type) => new
                    {
                        room, type
                    }).Where(p => p.type.Id == filter.SeleccionarTipoHabitacion);
            }

            if (filter.TotalHabitaciones != 0)
            {
                var countRooms = allRooms.Where(p => p.Fecha >= filter.Fecha).Where(p => p.Estado == Constants.message).Count();
                if (filter.TotalHabitaciones > countRooms)
                {
                    roomList.Add(new RoomModel 
                    {
                        Response = Constants.valorNoValido
                    });
                    return roomList.ToList();
                }
                int count = Constants.variableEnCero;

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

            var roomById = mapper.Map<Domain.Models.RoomModel>(room);

            return roomById;
        }

        public async Task<Rooms> Update(RoomModel room)
        {
            var roomMapper = mapper.Map<Infrastructure.Entities.Rooms>(room);

            var roomUpdate = await habitacionesRepository.Update(roomMapper);

            return roomUpdate;
        }
    }
}
