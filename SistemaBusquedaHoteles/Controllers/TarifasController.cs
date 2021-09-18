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
    public class TarifasController : ControllerBase
    {
        private readonly ITarifasApplication tarifasApplication;

        public TarifasController(ITarifasApplication tarifasApplication)
        {
            this.tarifasApplication = tarifasApplication;
        }

        [HttpGet]
        public IEnumerable<Rates> GetTarifas(TarifasQueryFilter filter)
        {
            return tarifasApplication.GetTarifas(filter);
        }

        [HttpGet("{id}")]
        public Rates GetTarifaById(int id)
        {
            return tarifasApplication.GetTarifaById(id);
        }
    }
}
