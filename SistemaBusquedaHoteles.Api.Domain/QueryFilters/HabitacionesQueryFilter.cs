using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.QueryFilters
{
    public class HabitacionesQueryFilter
    {
        public DateTime? Fecha { get; set; }
        public string Ciudad { get; set; }
        public double Tarifa { get; set; }
        public int CantidadPersonas { get; set; }
        public string Tipo { get; set; }
        public int TotalHabitaciones { get; set; }
        
        ////pendiente de realizar.
        //public double TotalPagar { get; set; }
        //public double Total()
        //{
        //    double total = 0;
        //    total = TotalHabitaciones * Tarifa;
        //    return total;
        //}
    }
}
