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
        IEnumerable<Habitaciones> GetAll();
        Habitaciones GetById(int id);
        Habitaciones Create(Habitaciones habitaciones);
        Habitaciones Update(Habitaciones habitaciones);
        void Delete(int id);
    }
}
