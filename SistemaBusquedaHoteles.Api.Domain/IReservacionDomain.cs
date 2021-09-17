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
        ReservacionViewModel CreateReservacion(Reservacion reservacion);
        ReservacionViewModel UpdateReservacion(ReservacionViewModel reservacion);
        void DeleteReservacion(int id);


        DateTime ValidarFechasDisponibles(DateTime? fecha);
        double TarifasDisponibles(DateTime? fecha, string tipoHabitacion);
        int CalcularHabitacionesDisponibles(string ciudad);
    }
}
