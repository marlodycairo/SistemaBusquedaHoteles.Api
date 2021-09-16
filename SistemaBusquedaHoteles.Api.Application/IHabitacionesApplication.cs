using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface IHabitacionesApplication
    {
        IEnumerable<HabitacionesViewModel> GetAll();
        HabitacionesViewModel GetById(int id);
        HabitacionesViewModel Create(HabitacionesViewModel habitaciones);
        HabitacionesViewModel Update(HabitacionesViewModel habitaciones);
        void Delete(int id);
    }
}
