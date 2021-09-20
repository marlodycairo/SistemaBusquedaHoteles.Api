using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Helpers;
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

        public HabitacionesDomainServices(IHabitacionesRepository habitacionesRepository, IMapper mapper)
        {
            this.habitacionesRepository = habitacionesRepository;
            this.mapper = mapper;
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

            if (filter.Ciudad != 0)
            {
                
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
