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
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsApplication habitacionesApplication;

        public RoomsController(IRoomsApplication habitacionesApplication)
        {
            this.habitacionesApplication = habitacionesApplication;
        }

        [HttpGet]
        public async Task<ActionResult<RoomModel>> GetHabitaciones([FromQuery] HabitacionesQueryFilterModel filter)
        {
            IEnumerable<RoomModel> rooms = await habitacionesApplication.GetAll(filter);

            if (rooms == null)
            {
                return NotFound();
            }

            return Ok(rooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> GetHabitacionById(int id)
        {
            RoomModel room = await habitacionesApplication.GetById(id);

            if (room == null)
            {
                return NotFound();
            }
            return room;
        }

        [HttpPost]
        public async Task<ActionResult<RoomModel>> CreateHabitacion(RoomModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            RoomModel roomCreate = await habitacionesApplication.Create(model);
            return Ok(roomCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHabitacion(int id, RoomModel room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }
            Api.Infrastructure.Entities.Rooms roomUpdate = await habitacionesApplication.Update(room);
            return Ok(roomUpdate);
        }

        [HttpDelete("{id}")]
        public async Task DeleteHabitacion(int id)
        {
            await habitacionesApplication.Delete(id);
        }
    }
}
