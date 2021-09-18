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
    public class TipoAlojamientosController : ControllerBase
    {
        private readonly ITipoAlojamientoApplication tipoAlojamientoApplication;

        public TipoAlojamientosController(ITipoAlojamientoApplication tipoAlojamientoApplication)
        {
            this.tipoAlojamientoApplication = tipoAlojamientoApplication;
        }

        [HttpGet]
        public IEnumerable<RoomType> GetHabitaciones()
        {
            return tipoAlojamientoApplication.GetAlojamientos();
        }

        [HttpGet("{id}")]
        public RoomType GetHabitacionById(int id)
        {
            return tipoAlojamientoApplication.GetAlojamientoById(id);
        }
    }
}
