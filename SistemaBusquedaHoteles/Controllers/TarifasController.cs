﻿using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<Rates>> GetTarifas()
        {
            var rates = await tarifasApplication.GetTarifas();
            return Ok(rates);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rates>> GetTarifaById(int id)
        {
            var rate = await tarifasApplication.GetTarifaById(id);
            if (rate == null)
            {
                return NotFound();
            }
            return rate;
        }
    }
}
