using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface IRoomsDomain
    {
        Task<IEnumerable<RoomModel>> GetAll(HabitacionesQueryFilterModel filter);
        Task<RoomModel> GetById(int id);
        Task<RoomModel> Create(Rooms habitaciones);
        Task<Rooms> Update(RoomModel habitaciones);
        Task Delete(int id);
    }
}
