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
        IEnumerable<Models.Reservation> GetReservaciones(ReservacionQueryFilter filter);
        Models.Reservation GetReservaById(int id);
        Models.Reservation CreateReservacion(Infrastructure.Entities.Reservation reservacion);
        Models.Reservation UpdateReservacion(Models.Reservation reservacion);
        void DeleteReservacion(int id);

        DateTime ValidarFechasDisponibles(DateTime? fecha);
        double TarifasDisponibles(DateTime? fecha, int tipoHabitacion);
        int CalcularHabitacionesDisponibles(int ciudad);
    }
}
