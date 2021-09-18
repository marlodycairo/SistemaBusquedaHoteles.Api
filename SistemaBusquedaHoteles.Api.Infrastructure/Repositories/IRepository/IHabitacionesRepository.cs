using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository
{
    public interface IHabitacionesRepository
    {
        IEnumerable<Rooms> GetAll();
        Rooms GetById(int id);
        Rooms Create(Rooms habitaciones);
        Rooms Update(Rooms habitaciones);
        void Delete(int id);
    }
}
