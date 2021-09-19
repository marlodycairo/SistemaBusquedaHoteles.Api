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

            var roomCreate = await habitacionesDomain.Create(roomMapper);

            return roomCreate;
        }

        public async Task Delete(int id)
        {
            await habitacionesDomain.Delete(id);
        }

        public async Task<IEnumerable<Room>> GetAll()
        {
            return await habitacionesDomain.GetAll();
        }

        public async Task<Room> GetById(int id)
        {
            return await habitacionesDomain.GetById(id);
        }

        public async Task<Rooms> Update(Room model)
        {
            return await habitacionesDomain.Update(model);
        }
    }
}
