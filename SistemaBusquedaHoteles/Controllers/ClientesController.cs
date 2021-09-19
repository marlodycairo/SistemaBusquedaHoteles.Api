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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteApplication clienteApplication;

        public ClientesController(IClienteApplication clienteApplication)
        {
            this.clienteApplication = clienteApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customers = await clienteApplication.GetClientes();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetClienteById(int id)
        {
            var customer = await clienteApplication.GetClienteById(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomersModel>> CreateClientes(CustomersModel customer)
        {
            var customerCreate = await clienteApplication.CreateCliente(customer);
            if (customerCreate == null)
            {
                return BadRequest();
            }
            return Ok(customerCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, CustomersModel customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }
            var customerUpdate = await clienteApplication.UpdateCliente(customer);
            if (customerUpdate == null)
            {
                return NotFound();
            }
            return Ok(customerUpdate);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            await clienteApplication.DeleteCliente(id);
            return Ok();
        }
    }
}
