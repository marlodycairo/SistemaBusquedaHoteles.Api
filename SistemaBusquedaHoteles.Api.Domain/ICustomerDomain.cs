using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.ResponseModels;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface ICustomerDomain
    {
        Task<IEnumerable<CustomersModel>> GetClientes();
        Task<CustomersModel> GetClienteById(int id);
        Task<CustomerResponseModel> CreateCliente(CustomersModel customer);
        Task<Customer> UpdateCliente(CustomersModel customer);
        Task DeleteCliente(int id);
    }
}
