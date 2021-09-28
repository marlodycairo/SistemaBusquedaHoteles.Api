using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface ICustomerDomain
    {
        Task<IEnumerable<CustomersModel>> GetClientes();
        Task<CustomersModel> GetClienteById(int id);
        Task<CustomersModel> CreateCliente(CustomersModel customer);
        Task<Customer> UpdateCliente(CustomersModel customer);
        Task DeleteCliente(int id);
    }
}
