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
        IEnumerable<Domain.Models.Customer> GetClientes();
        Domain.Models.Customer GetClienteById(int id);
        Domain.Models.Customer CreateCliente(Domain.Models.Customer clientes);
        Domain.Models.Customer UpdateCliente(Domain.Models.Customer clientes);
        void DeleteCliente(int id);
    }
}
