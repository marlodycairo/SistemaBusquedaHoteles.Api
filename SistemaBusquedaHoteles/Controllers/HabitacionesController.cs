using Microsoft.AspNetCore.Mvc;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using System.Collections.Generic;

namespace SistemaBusquedaHoteles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionesController : ControllerBase
    {
        private readonly IHabitacionesApplication habitacionesApplication;

        public HabitacionesController(IHabitacionesApplication habitacionesApplication)
        {
            this.habitacionesApplication = habitacionesApplication;
        }

        [HttpGet]
        public IEnumerable<HabitacionesViewModel> GetHabitaciones([FromQuery] HabitacionesQueryFilter filter)
        {
            return habitacionesApplication.GetAll(filter);
        }

        [HttpGet("{id}")]
        public HabitacionesViewModel GetHabitacionById(int id)
        {
            return habitacionesApplication.GetById(id);
        }

        [HttpPost]
        public ActionResult<HabitacionesViewModel> CreateHabitacion(HabitacionesViewModel model)
        {
            return habitacionesApplication.Create(model);
        }

        [HttpPut("{id}")]
        public HabitacionesViewModel UpdateHabitacion(HabitacionesViewModel model)
        {
            return habitacionesApplication.Update(model);
        }

        [HttpDelete("{id}")]
        public void DeleteHabitacion(int id)
        {
            habitacionesApplication.Delete(id);
        }
    }
}
