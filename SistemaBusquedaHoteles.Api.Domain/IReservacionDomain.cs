using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface IReservacionDomain
    {
        IEnumerable<ReservacionViewModel> GetReservaciones(ReservacionQueryFilter filter);
        ReservacionViewModel GetReservaById(int id);
        ReservacionViewModel CreateReservacion(Reservation reservacion);
        ReservacionViewModel UpdateReservacion(ReservacionViewModel reservacion);
        void DeleteReservacion(int id);

        DateTime ValidarFechasDisponibles(DateTime? fecha);
        double TarifasDisponibles(DateTime? fecha, int tipoHabitacion);
        int CalcularHabitacionesDisponibles(int ciudad);
    }
}
