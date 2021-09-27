using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Domain.ResponseModels;
using SistemaBusquedaHoteles.Api.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerApplication clienteApplication;

        public CustomerController(ICustomerApplication clienteApplication)
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
        public async Task<ActionResult<CustomerResponseModel>> CreateClientes(CustomersModel customer)
        {
            var customerCreate = await clienteApplication.CreateCliente(customer);

            if (customerCreate == null)
            {
                return BadRequest();
            }

            //return new CustomersModel { IDCliente = customer.IDCliente, NombreCliente = customer.NombreCliente };
            return new CustomerResponseModel { Response = ResponseMessages.SuccedSavedRegister };

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(string id, CustomersModel customer)
        {
            if (id != customer.IDCliente)
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
