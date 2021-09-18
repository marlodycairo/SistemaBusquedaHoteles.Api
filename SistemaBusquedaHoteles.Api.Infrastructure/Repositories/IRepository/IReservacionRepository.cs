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
        Task<IEnumerable<Reservation>> GetReservaciones();
        Task<Reservation> GetReservaById(int id);
        Task<Reservation> CreateReservacion(Reservation reservacion);
        Task<Reservation> UpdateReservacion(Reservation reservacion);
        Task DeleteReservacion(int id);
        bool ReservationExists(int id);
    }
}
