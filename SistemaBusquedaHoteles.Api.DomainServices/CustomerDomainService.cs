﻿using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.ResponseModels;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using SistemaBusquedaHoteles.Api.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<CustomerResponseModel> CreateCliente(CustomersModel customer)
        {
            var customerMapper = mapper.Map<Customer>(customer);

            await clienteRepository.CreateCliente(customerMapper);

            return new CustomerResponseModel { Response = ResponseMessages.SuccedSavedRegister };
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
