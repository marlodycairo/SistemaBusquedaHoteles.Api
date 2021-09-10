using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain.Models;
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
        public IEnumerable<ReservacionViewModel> VerTodasLasReservas()
        {
            return reservacionApplication.GetReservaciones();
        }

        [HttpGet("{id}")]
        public ReservacionViewModel GetReservacionById(int id)
        {
            return reservacionApplication.GetReservaById(id);
        }
    }
}
