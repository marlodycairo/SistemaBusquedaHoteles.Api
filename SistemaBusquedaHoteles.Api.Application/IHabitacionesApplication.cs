using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface IHabitacionesApplication
    {
        Task<IEnumerable<RoomModel>> GetAll();
        Task<RoomModel> GetById(int id);
        Task<RoomModel> Create(RoomModel room);
        Task<Rooms> Update(RoomModel room);
        Task Delete(int id);
    }
}
