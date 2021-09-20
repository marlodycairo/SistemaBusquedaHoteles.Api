using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationAndRoomsController : ControllerBase
    {
        private readonly IReservationRoomApplication reservationRoomApplication;

        public ReservationAndRoomsController(IReservationRoomApplication reservationRoomApplication)
        {
            this.reservationRoomApplication = reservationRoomApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservesAndRooms([FromQuery] ReservacionQueryFilter filter)
        {
            if (filter == null)
            {
                return BadRequest();
            }
            var allReservesAndRooms = await reservationRoomApplication.GetAllReservesRooms(filter);
            return Ok(allReservesAndRooms);
        }
    }
}
