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
        public async Task<ActionResult<RoomModel>> GetHabitaciones([FromQuery] ReservacionQueryFilter filter)
        {
            var rooms = await habitacionesApplication.GetAll(filter);
            if (rooms == null)
            {
                return NotFound();
            }
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> GetHabitacionById(int id)
        {
            var room = await habitacionesApplication.GetById(id);
            if (room == null)
            {
                return NotFound();
            }
            return room;
        }

        [HttpPost]
        public async Task<ActionResult<RoomModel>> CreateHabitacion(RoomModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var roomCreate = await habitacionesApplication.Create(model);
            return Ok(roomCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitacion(int id, RoomModel room)
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
