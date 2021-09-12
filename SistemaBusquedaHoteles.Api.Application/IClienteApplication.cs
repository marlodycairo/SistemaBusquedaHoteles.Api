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
        IEnumerable<ClienteViewModel> GetClientes();
        ClienteViewModel GetClienteById(int id);
        ClienteViewModel CreateCliente(ClienteViewModel clientes);
        ClienteViewModel UpdateCliente(ClienteViewModel clientes);
        void DeleteCliente(int id);
    }
}
