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
    public class TarifasController : ControllerBase
    {
        private readonly ITarifasApplication tarifasApplication;

        public TarifasController(ITarifasApplication tarifasApplication)
        {
            this.tarifasApplication = tarifasApplication;
        }

        [HttpGet]
        public IEnumerable<TarifasViewModel> GetTarifas()
        {
            return tarifasApplication.GetTarifas();
        }

        [HttpGet("{id}")]
        public TarifasViewModel GetTarifaById(int id)
        {
            return tarifasApplication.GetTarifaById(id);
        }
    }
}
