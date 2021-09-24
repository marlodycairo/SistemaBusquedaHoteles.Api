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
    public class RoomsApplicationService : IRoomsApplication
    {
        private readonly IRoomsDomain habitacionesDomain;
        private readonly IMapper mapper;

        public RoomsApplicationService(IRoomsDomain habitacionesDomain, IMapper mapper)
        {
            this.habitacionesDomain = habitacionesDomain;
            this.mapper = mapper;
        }

        public async Task<RoomModel> Create(RoomModel room)
        {
            var roomMapper = mapper.Map<Rooms>(room);

            var roomCreate = await habitacionesDomain.Create(roomMapper);

            return roomCreate;
        }

        public async Task Delete(int id)
        {
            await habitacionesDomain.Delete(id);
        }

        public async Task<IEnumerable<RoomModel>> GetAll(HabitacionesQueryFilterModel filter)
        {
            return await habitacionesDomain.GetAll(filter);
        }

        public async Task<RoomModel> GetById(int id)
        {
            return await habitacionesDomain.GetById(id);
        }

        public async Task<Rooms> Update(RoomModel model)
        {
            return await habitacionesDomain.Update(model);
        }
    }
}
