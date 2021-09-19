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

        public async Task<Room> Create(Rooms room)
        {
            habitacionesRepository.Create(room);

            var roomCreate = mapper.Map<Room>(room);

            return roomCreate;
        }

        public async Task Delete(int id)
        {
            habitacionesRepository.Delete(id);
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            var rooms = habitacionesRepository.GetAll();

            var allRooms = mapper.Map<IEnumerable<Room>>(rooms);

            return allRooms;
        }

        public async Task<Room> GetById(int id)
        {
            var room = habitacionesRepository.GetById(id);

            var roomById = mapper.Map<Domain.Models.Room>(room);

            return roomById;
        }

        public async Task<Rooms> Update(Room room)
        {
            var roomMapper = mapper.Map<Infrastructure.Entities.Rooms>(room);

            var roomUpdate = habitacionesRepository.Update(roomMapper);

            return roomUpdate;
        }
    }
}
