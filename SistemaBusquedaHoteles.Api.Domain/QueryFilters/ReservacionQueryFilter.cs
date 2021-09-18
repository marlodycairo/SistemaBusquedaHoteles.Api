using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.QueryFilters
{
    public class ReservacionQueryFilter
    {
        public int Ciudad { get; set; }
        public DateTime? Fecha { get; set; }
        public int TotalPersonas { get; set; }
        public int TotalHabitaciones { get; set; }
        public int SeleccionarTipoHabitacion { get; set; }
    }
}
