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
        Task<IEnumerable<Customers>> GetClientes();
        Task<Customers> GetClienteById(int id);
        Task<Customers> CreateCliente(Customer customer);
        Task<Customer> UpdateCliente(Customers customer);
        Task DeleteCliente(int id);
    }
}
