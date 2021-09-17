using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Helpers.Constants
{
    public class Constants
    {
        public const string message = "disponible";
        public const string fechaNoDisponible = "Lo sentimos, no hay habitaciones disponibles para la fecha seleccionada { filter.Fecha }.";
        public const string superaCapacidadMax = "No hay habitaciones disponibles en la fecha { filter.Fecha } para alojar la cantidad de huespedes seleccionados. Recuerde que tiene la opción de reservar varias habitaciones.";

        public const string confirmartemporada = "alta";

        public const int totalHabitacionesDisponibles = 0;
        public const int totalOcupadas = 0;
        public const int totalDisponibles = 0;


    }
}
