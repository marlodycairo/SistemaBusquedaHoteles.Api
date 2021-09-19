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
    public class HabitacionesApplicationService : IHabitacionesApplication
    {
        private readonly IHabitacionesDomain habitacionesDomain;
        private readonly IMapper mapper;

        public HabitacionesApplicationService(IHabitacionesDomain habitacionesDomain, IMapper mapper)
        {
            this.habitacionesDomain = habitacionesDomain;
            this.mapper = mapper;
        }

        public async Task<Room> Create(Room room)
        {
            var roomMapper = mapper.Map<Rooms>(room);

            var roomCreate = habitacionesDomain.Create(roomMapper);

            return roomCreate;
        }

        public async Task Delete(int id)
        {
            habitacionesDomain.Delete(id);
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return habitacionesDomain.GetAll();
        }

        public async Task<Room> GetById(int id)
        {
            return habitacionesDomain.GetById(id);
        }

        public async Task<Room> Update(Domain.Models.Room model)
        {
            return habitacionesDomain.Update(model);
        }
    }
}
