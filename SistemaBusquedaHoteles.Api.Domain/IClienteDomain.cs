using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface IClienteDomain
    {
        Task<IEnumerable<CustomersModel>> GetClientes();
        Task<CustomersModel> GetClienteById(int id);
        Task<CustomersModel> CreateCliente(Customer customer);
        Task<Customer> UpdateCliente(CustomersModel customer);
        Task DeleteCliente(int id);
    }
}
