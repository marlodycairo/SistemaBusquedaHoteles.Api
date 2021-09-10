using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository
{
    public interface IReservacionRepository
    {
        IEnumerable<Reservacion> GetReservaciones();
        Reservacion GetReservaById(int id);
    }
}
