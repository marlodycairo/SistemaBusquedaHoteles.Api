using Microsoft.AspNetCore.Mvc;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain.Models;
using System.Collections.Generic;
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
            IEnumerable<CustomersModel> customers = await clienteApplication.GetClientes();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetClienteById(int id)
        {
            CustomersModel customer = await clienteApplication.GetClienteById(id);

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult<CustomersModel>> CreateClientes(CustomersModel customer)
        {
            CustomersModel customerCreate = await clienteApplication.CreateCliente(customer);

            return Ok(customerCreate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(CustomersModel customer)
        {
            var customerUpdate = await clienteApplication.UpdateCliente(customer);

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
