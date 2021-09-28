using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class CustomerDomainService : ICustomerDomain
    {
        private readonly ICustomerRepository clienteRepository;
        private readonly IMapper mapper;

        public CustomerDomainService(ICustomerRepository clienteRepository, IMapper mapper)
        {
            this.clienteRepository = clienteRepository;
            this.mapper = mapper;
        }

        public async Task<CustomersModel> CreateCliente(CustomersModel customer)
        {
            Customer customerMapper = mapper.Map<Customer>(customer);

            await clienteRepository.CreateCliente(customerMapper);

            return customer;
        }

        public async Task DeleteCliente(int id)
        {
            await clienteRepository.DeleteCliente(id);
        }

        public async Task<CustomersModel> GetClienteById(int id)
        {
            Customer customer = await clienteRepository.GetClienteById(id);

            CustomersModel customerMapper = mapper.Map<CustomersModel>(customer);

            return customerMapper;
        }

        public async Task<IEnumerable<CustomersModel>> GetClientes()
        {
            IEnumerable<Customer> allCustomers = await clienteRepository.GetClientes();

            IEnumerable<CustomersModel> customersMapper = mapper.Map<IEnumerable<Domain.Models.CustomersModel>>(allCustomers);

            return customersMapper;
        }

        public async Task<Customer> UpdateCliente(CustomersModel customers)
        {
            Customer customerMapper = mapper.Map<Customer>(customers);

            Customer customerUpdate = await clienteRepository.UpdateCliente(customerMapper);

            return customerUpdate;
        }
    }
}
