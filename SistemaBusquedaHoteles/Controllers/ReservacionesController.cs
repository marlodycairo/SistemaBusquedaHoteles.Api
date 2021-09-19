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
    public class ReservacionesController : ControllerBase
    {
        private readonly IReservacionApplication reservacionApplication;

        public ReservacionesController(IReservacionApplication reservacionApplication)
        {
            this.reservacionApplication = reservacionApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservaciones([FromQuery] ReservacionQueryFilter filter)
        {
            if (filter == null)
            {
                return BadRequest();
            }
            var reservaciones = await reservacionApplication.GetReservaciones(filter);
            return Ok(reservaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservations>> GetReservacionById(int id)
        {
            var reservacion = await reservacionApplication.GetReservationById(id);

            if (reservacion == null)
            {
                return NotFound();
            }
            return reservacion;
        }

        [HttpPost]
        public async Task<ActionResult<Reservations>> CreateReservation(Reservations reservacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var nuevaReservacion = await reservacionApplication.CreateReservation(reservacion);

            return Ok(nuevaReservacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservacion(int id, Reservations reservacion)
        {
            if (id != reservacion.Id)
            {
                return BadRequest();
            }
            await reservacionApplication.UpdateReservation(reservacion);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservacion(int id)
        {
            var reservation = reservacionApplication.DeleteReservacion(id);

            if (reservation == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
