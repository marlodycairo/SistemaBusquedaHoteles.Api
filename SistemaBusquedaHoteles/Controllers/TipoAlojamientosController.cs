﻿using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<RoomType>> GetHabitaciones()
        {
            var roomTypes = tipoAlojamientoApplication.GetAlojamientos();
            if (roomTypes == null)
            {
                return NotFound();
            }
            return Ok(roomTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomType>> GetHabitacionById(int id)
        {
            var roomType = tipoAlojamientoApplication.GetAlojamientoById(id);
            if (roomType == null)
            {
                return NotFound();
            }
            return roomType;
        }
    }
}
