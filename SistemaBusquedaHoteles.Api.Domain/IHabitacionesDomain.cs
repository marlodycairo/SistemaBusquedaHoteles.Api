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
        IEnumerable<HabitacionesViewModel> GetAll();
        HabitacionesViewModel GetById(int id);
        HabitacionesViewModel Create(Habitaciones habitaciones);
        HabitacionesViewModel Update(HabitacionesViewModel habitaciones);
        void Delete(int id);
    }
}
