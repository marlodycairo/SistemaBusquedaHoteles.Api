using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface IReservacionDomain
    {
        Task<IEnumerable<Reservations>> GetReservaciones(ReservacionQueryFilter filter);
        Task<Reservations> GetReservationById(int id);
        Task<Reservations> CreateReservacion(Reservation reservacion);
        Task<Reservations> UpdateReservacion(Reservations reservacion);
        Task DeleteReservacion(int id);

        DateTime ValidarFechasDisponibles(DateTime? fecha);
        double TarifasDisponibles(DateTime? fecha, int tipoHabitacion);
        int CalcularHabitacionesDisponibles(int ciudad);
    }
}
