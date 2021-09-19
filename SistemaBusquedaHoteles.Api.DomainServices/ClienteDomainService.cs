using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class ClienteDomainService : IClienteDomain
    {
        private readonly IClienteRepository clienteRepository;
        private readonly IMapper mapper;

        public ClienteDomainService(IClienteRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<CustomersModel> CreateCliente(Customer customer)
        {
            await clienteRepository.CreateCliente(customer);

            var customerMapper = mapper.Map<CustomersModel>(customer);

            return customerMapper;
        }

        public async Task DeleteCliente(int id)
        {
            await clienteRepository.DeleteCliente(id);
        }

        public async Task<CustomersModel> GetClienteById(int id)
        {
            var customer = await clienteRepository.GetClienteById(id);

            var customerMapper = mapper.Map<CustomersModel>(customer);

            return customerMapper;
        }

        public async Task<IEnumerable<CustomersModel>> GetClientes()
        {
            var allCustomers = await clienteRepository.GetClientes();

            var customersMapper = mapper.Map<IEnumerable<Domain.Models.CustomersModel>>(allCustomers);

            return customersMapper;
        }

        public async Task<Customer> UpdateCliente(CustomersModel customers)
        {
            var customerMapper = mapper.Map<Customer>(customers);

            var customerUpdate = await clienteRepository.UpdateCliente(customerMapper);

            return customerUpdate;
        }
    }
}
