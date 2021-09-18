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
        IEnumerable<Models.Customer> GetClientes();
        Models.Customer GetClienteById(int id);
        Models.Customer CreateCliente(Infrastructure.Entities.Customer clientes);
        Models.Customer UpdateCliente(Models.Customer clientes);
        void DeleteCliente(int id);
    }
}
