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
        public IEnumerable<SedesViewModel> GetHabitaciones()
        {
            return sedesApplication.GetSedes();
        }

        [HttpGet("{id}")]
        public SedesViewModel GetHabitacionById(int id)
        {
            return sedesApplication.GetSedeById(id);
        }
    }
}
