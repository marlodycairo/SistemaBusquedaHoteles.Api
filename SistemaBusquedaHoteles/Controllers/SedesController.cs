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
        public async Task<ActionResult<LocationsModel>> GetHabitaciones()
        {
            var locations = await sedesApplication.GetSedes();
            if (locations == null)
            {
                return NotFound();
            }
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LocationsModel>> GetHabitacionById(int id)
        {
            var location = await sedesApplication.GetSedeById(id);
            if (location == null)
            {
                return NotFound();
            }
            return location;
        }
    }
}
