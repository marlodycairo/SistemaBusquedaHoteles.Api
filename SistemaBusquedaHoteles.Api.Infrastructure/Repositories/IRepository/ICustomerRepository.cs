using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetClientes();
        Task<Customer> GetClienteById(int id);
        Task<Customer> CreateCliente(Customer clientes);
        Task<Customer> UpdateCliente(Customer clientes);
        Task DeleteCliente(int id);
    }
}
