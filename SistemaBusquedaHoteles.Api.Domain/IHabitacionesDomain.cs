using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface IHabitacionesDomain
    {
        Task<IEnumerable<Room>> GetAll();
        Task<Room> GetById(int id);
        Task<Room> Create(Infrastructure.Entities.Rooms habitaciones);
        Task<Rooms> Update(Room habitaciones);
        Task Delete(int id);
    }
}
