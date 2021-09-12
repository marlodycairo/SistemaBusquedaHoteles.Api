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
        IEnumerable<Clientes> GetClientes();
        Clientes GetClienteById(int id);
        Clientes CreateCliente(Clientes clientes);
        Clientes UpdateCliente(Clientes clientes);
        void DeleteCliente(int id);
    }
}
