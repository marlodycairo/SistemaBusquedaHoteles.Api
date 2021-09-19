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

            var customers = clienteApplication.GetClientes();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetClienteById(int id)
        {
            var customer = clienteApplication.GetClienteById(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateClientes(Customer model)
        {
            return clienteApplication.CreateCliente(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(Customer customer)
        {
            var customerUpdate = clienteApplication.UpdateCliente(customer);
            return Ok(customerUpdate);
        }

        [HttpDelete("{id}")]
        public async Task DeleteCliente(int id)
        {
            clienteApplication.DeleteCliente(id);
        }
    }
}
