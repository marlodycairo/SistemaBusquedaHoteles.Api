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
        Task<IEnumerable<Room>> GetAll();
        Task<Room> GetById(int id);
        Task<Room> Create(Room room);
        Task<Rooms> Update(Room room);
        Task Delete(int id);
    }
}
