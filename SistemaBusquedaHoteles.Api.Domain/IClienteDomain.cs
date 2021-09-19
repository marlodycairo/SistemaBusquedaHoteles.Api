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
        IEnumerable<Models.Customers> GetClientes();
        Models.Customers GetClienteById(int id);
        Models.Customers CreateCliente(Infrastructure.Entities.Customer clientes);
        Models.Customers UpdateCliente(Models.Customers clientes);
        void DeleteCliente(int id);
    }
}
