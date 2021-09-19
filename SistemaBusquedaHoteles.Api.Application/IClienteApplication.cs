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
        Task<IEnumerable<CustomersModel>> GetClientes();
        Task<CustomersModel> GetClienteById(int id);
        Task<CustomersModel> CreateCliente(CustomersModel customers);
        Task<Customer> UpdateCliente(CustomersModel customers);
        Task DeleteCliente(int id);
    }
}
