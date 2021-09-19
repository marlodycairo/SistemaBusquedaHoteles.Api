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
    public class SedesController : ControllerBase
    {
        private readonly ISedesApplication sedesApplication;

        public SedesController(ISedesApplication sedesApplication)
        {
            this.sedesApplication = sedesApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetHabitaciones()
        {
            var locations = sedesApplication.GetSedes();
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<Locations> GetHabitacionById(int id)
        {
            return sedesApplication.GetSedeById(id);
        }
    }
}
