using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.QueryFilters
{
    public class HabitacionesQueryFilterModel
    {
        public DateTime? Fecha { get; set; }
        public int Ciudad { get; set; }
        public int Tarifa { get; set; }
        public int CantidadPersonas { get; set; }
        public int Tipo { get; set; }
        public int TotalHabitaciones { get; set; }
    }
}
