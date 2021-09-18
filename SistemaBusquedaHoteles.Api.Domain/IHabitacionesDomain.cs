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
        IEnumerable<Models.Rooms> GetAll();
        Models.Rooms GetById(int id);
        Models.Rooms Create(Infrastructure.Entities.Rooms habitaciones);
        Models.Rooms Update(Models.Rooms habitaciones);
        void Delete(int id);
    }
}
