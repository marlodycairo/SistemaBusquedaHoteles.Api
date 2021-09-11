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
        public IEnumerable<ReservacionViewModel> VerTodasLasReservas([FromQuery] ReservacionQueryFilter filter)
        {
            return reservacionApplication.GetReservaciones(filter);
        }

        [HttpGet("{id}")]
        public ReservacionViewModel GetReservacionById(int id)
        {
            return reservacionApplication.GetReservaById(id);
        }

        [HttpPost]
        public ReservacionViewModel CreateReservacion(ReservacionViewModel reservacion)
        {
            return reservacionApplication.CreateReservacion(reservacion);
        }

        [HttpPut]
        public ReservacionViewModel UpdateReservacion(ReservacionViewModel reservacion)
        {
            return reservacionApplication.UpdateReservacion(reservacion);
        }

        [HttpDelete("{id}")]
        public void DeleteReservacion(int id)
        {
            reservacionApplication.DeleteReservacion(id);
        }
    }
}
