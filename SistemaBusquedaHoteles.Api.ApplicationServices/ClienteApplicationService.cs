﻿using AutoMapper;
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

        public async Task<CustomersModel> CreateCliente(CustomersModel customer)
        {
            var allCustomers = mapper.Map<Customer>(customer);
            var customerCreate = await clienteDomain.CreateCliente(allCustomers);
            return customerCreate;
        }

        public async Task DeleteCliente(int id)
        {
            await clienteDomain.DeleteCliente(id);
        }

        public async Task<CustomersModel> GetClienteById(int id)
        {
            return await clienteDomain.GetClienteById(id);
        }

        public async Task<IEnumerable<CustomersModel>> GetClientes()
        {
            return await clienteDomain.GetClientes();
        }

        public async Task<Customer> UpdateCliente(CustomersModel clientes)
        {
            return await clienteDomain.UpdateCliente(clientes);
        }
    }
}
