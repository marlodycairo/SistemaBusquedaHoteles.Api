using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface IReservacionApplication
    {
        IEnumerable<Reservation> GetReservaciones(ReservacionQueryFilter filter);
        Reservation GetReservaById(int id);
        Reservation CreateReservacion(Reservation reservacion);
        Reservation UpdateReservacion(Reservation reservacion);
        void DeleteReservacion(int id);
    }
}
