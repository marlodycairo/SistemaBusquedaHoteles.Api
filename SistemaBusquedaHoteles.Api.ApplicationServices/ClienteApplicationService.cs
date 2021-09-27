using AutoMapper;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.ResponseModels;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.ApplicationServices
{
    public class ClienteApplicationService : ICustomerApplication
    {
        private readonly ICustomerDomain clienteDomain;

        public ClienteApplicationService(ICustomerDomain clienteDomain)
        {
            this.clienteDomain = clienteDomain;
        }

        public async Task<CustomerResponseModel> CreateCliente(CustomersModel customer)
        {
            await clienteDomain.CreateCliente(customer);

            return new CustomerResponseModel { Response = ResponseMessages.SuccedSavedRegister };
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
