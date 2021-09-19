using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface IReservacionApplication
    {
        Task<IEnumerable<ReservationsModel>> GetReservaciones(ReservacionQueryFilter filter);
        Task<ReservationsModel> GetReservationById(int id);
        Task<ReservationsModel> CreateReservation(ReservationsModel reservacion);
        Task<Reservation> UpdateReservation(ReservationsModel reservacion);
        Task DeleteReservacion(int id);
    }
}
