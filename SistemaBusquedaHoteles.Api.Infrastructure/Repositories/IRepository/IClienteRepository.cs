using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository
{
    public interface IClienteRepository
    {
        IEnumerable<Customer> GetClientes();
        Customer GetClienteById(int id);
        Customer CreateCliente(Customer clientes);
        Customer UpdateCliente(Customer clientes);
        void DeleteCliente(int id);
    }
}
