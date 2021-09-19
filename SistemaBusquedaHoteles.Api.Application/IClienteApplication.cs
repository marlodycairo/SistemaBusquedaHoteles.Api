using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface IClienteApplication
    {
        Task<IEnumerable<Customers>> GetClientes();
        Task<Customers> GetClienteById(int id);
        Task<Customers> CreateCliente(Customers customers);
        Task<Customer> UpdateCliente(Customers customers);
        Task DeleteCliente(int id);
    }
}
