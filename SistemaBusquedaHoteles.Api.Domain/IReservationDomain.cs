using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface IReservationDomain
    {
        Task<IEnumerable<ReservationsModel>> GetReservaciones(ReservacionQueryFilterModel filter);
        Task<ReservationsModel> GetReservationById(int id);
        Task<ReservationsModel> CreateReservacion(Reservation reservacion);
        Task<Reservation> UpdateReservacion(ReservationsModel reservacion);
        Task DeleteReservacion(int id);
    }
}
