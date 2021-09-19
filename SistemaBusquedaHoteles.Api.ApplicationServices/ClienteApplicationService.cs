using AutoMapper;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.ApplicationServices
{
    public class ClienteApplicationService : IClienteApplication
    {
        private readonly IClienteDomain clienteDomain;
        private readonly IMapper mapper;

        public ClienteApplicationService(IClienteDomain clienteDomain, IMapper mapper)
        {
            this.clienteDomain = clienteDomain;
            this.mapper = mapper;
        }

        public async Task<Customers> CreateCliente(Customers customer)
        {
            var allCustomers = mapper.Map<Customer>(customer);
            var customerCreate = clienteDomain.CreateCliente(allCustomers);
            return customerCreate;
        }

        public async Task DeleteCliente(int id)
        {
            clienteDomain.DeleteCliente(id);
        }

        public async Task<Customers> GetClienteById(int id)
        {
            return clienteDomain.GetClienteById(id);
        }

        public async Task<IEnumerable<Customers>> GetClientes()
        {
            return clienteDomain.GetClientes();
        }

        public async Task<Customers> UpdateCliente(Customers clientes)
        {
            return clienteDomain.UpdateCliente(clientes);
        }
    }
}
