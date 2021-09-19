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
        IEnumerable<Models.Room> GetAll();
        Models.Room GetById(int id);
        Models.Room Create(Infrastructure.Entities.Rooms habitaciones);
        Models.Room Update(Models.Room habitaciones);
        void Delete(int id);
    }
}
