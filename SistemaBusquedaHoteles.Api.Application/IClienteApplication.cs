using SistemaBusquedaHoteles.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface IClienteApplication
    {
        IEnumerable<ClienteViewModel> GetReservaciones();
        ClienteViewModel GetReservaById(int id);
        ClienteViewModel CreateReservacion(ClienteViewModel clientes);
        ClienteViewModel UpdateReservacion(ClienteViewModel clientes);
        void DeleteReservacion(int id);
    }
}
