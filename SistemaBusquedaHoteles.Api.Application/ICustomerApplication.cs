using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.ResponseModels;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface ICustomerApplication
    {
        Task<IEnumerable<CustomersModel>> GetClientes();
        Task<CustomersModel> GetClienteById(int id);
        Task<CustomersModel> CreateCliente(CustomersModel customers);
        Task<Customer> UpdateCliente(CustomersModel customers);
        Task DeleteCliente(int id);
    }
}
