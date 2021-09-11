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
        IEnumerable<ClienteViewModel> GetReservaciones();
        ClienteViewModel GetReservaById(int id);
        ClienteViewModel CreateReservacion(Clientes clientes);
        ClienteViewModel UpdateReservacion(ClienteViewModel clientes);
        void DeleteReservacion(int id);
    }
}
