using Microsoft.AspNetCore.Mvc;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<Room>> GetHabitaciones()
        {
            var rooms = await habitacionesApplication.GetAll();
            if (rooms == null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetHabitacionById(int id)
        {
            var room = await habitacionesApplication.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            return room;
        }

        [HttpPost]
        public async Task<ActionResult<Room>> CreateHabitacion(Room model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var roomCreate = await habitacionesApplication.Create(model);
            return Ok(roomCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitacion(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }
            var roomUpdate = await habitacionesApplication.Update(room);
            return Ok(roomUpdate);
        }

        [HttpDelete("{id}")]
        public async Task DeleteHabitacion(int id)
        {
            await habitacionesApplication.Delete(id);
        }
    }
}
