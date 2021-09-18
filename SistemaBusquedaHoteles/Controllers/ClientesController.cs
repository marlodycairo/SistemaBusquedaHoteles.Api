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
        public IEnumerable<Customer> GetClientes()
        {
            return clienteApplication.GetClientes();
        }

        [HttpGet("{id}")]
        public Customer GetClienteById(int id)
        {
            return clienteApplication.GetClienteById(id);
        }

        [HttpPost]
        public Customer CreateClientes(Customer model)
        {
            return clienteApplication.CreateCliente(model);
        }

        [HttpPut]
        public Customer UpdateCliente(Customer cliente)
        {
            return clienteApplication.UpdateCliente(cliente);
        }

        [HttpDelete("{id}")]
        public void DeleteCliente(int id)
        {
            clienteApplication.DeleteCliente(id);
        }
    }
}
