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
        Task<IEnumerable<Reservations>> GetReservaciones(ReservacionQueryFilter filter);
        Task<Reservations> GetReservationById(int id);
        Task<Reservations> CreateReservation(Reservations reservacion);
        Task<Reservations> UpdateReservation(Reservations reservacion);
        Task DeleteReservacion(int id);
    }
}
