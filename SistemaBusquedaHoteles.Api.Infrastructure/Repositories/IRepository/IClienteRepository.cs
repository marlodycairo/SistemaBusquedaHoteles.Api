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
        IEnumerable<Clientes> GetReservaciones();
        Clientes GetReservaById(int id);
        Clientes CreateReservacion(Clientes clientes);
        Clientes UpdateReservacion(Clientes clientes);
        void DeleteReservacion(int id);
    }
}
