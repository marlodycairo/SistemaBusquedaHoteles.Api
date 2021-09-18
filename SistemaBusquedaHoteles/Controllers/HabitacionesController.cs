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
        public IEnumerable<Rooms> GetHabitaciones()
        {
            return habitacionesApplication.GetAll();
        }

        [HttpGet("{id}")]
        public Rooms GetHabitacionById(int id)
        {
            return habitacionesApplication.GetById(id);
        }

        [HttpPost]
        public ActionResult<Rooms> CreateHabitacion(Rooms model)
        {
            return habitacionesApplication.Create(model);
        }

        [HttpPut("{id}")]
        public Rooms UpdateHabitacion(Rooms model)
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
