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
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationApplication reservacionApplication;

        public ReservationsController(IReservationApplication reservacionApplication)
        {
            this.reservacionApplication = reservacionApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservaciones([FromQuery] ReservacionQueryFilterModel filter)
        {
            if (filter == null)
            {
                return BadRequest();
            }
            var reservaciones = await reservacionApplication.GetReservaciones(filter);
            return Ok(reservaciones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationsModel>> GetReservacionById(int id)
        {
            var reservacion = await reservacionApplication.GetReservationById(id);

            if (reservacion == null)
            {
                return NotFound();
            }
            return reservacion;
        }

        [HttpPost]
        public async Task<ActionResult<ReservationsModel>> CreateReservation(ReservationsModel reservacion)
        {
            if (reservacion == null)
            {
                return BadRequest();
            }
            var nuevaReservacion = await reservacionApplication.CreateReservation(reservacion);

            return Ok(nuevaReservacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservacion(int id, ReservationsModel reservacion)
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
            await reservacionApplication.DeleteReservacion(id);
            return Ok();
        }
    }
}
