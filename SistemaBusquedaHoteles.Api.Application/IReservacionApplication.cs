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
        IEnumerable<ReservacionViewModel> GetReservaciones(ReservacionQueryFilter filter);
        ReservacionViewModel GetReservaById(int id);
        ReservacionViewModel CreateReservacion(ReservacionViewModel reservacion);
        ReservacionViewModel UpdateReservacion(ReservacionViewModel reservacion);
        void DeleteReservacion(int id);
    }
}
