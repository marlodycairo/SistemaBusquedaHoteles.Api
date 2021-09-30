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
        public const string fechaNoDisponible = "Lo sentimos, no hay habitaciones disponibles para la fecha seleccionada.";
        public const string superaCapacidadMax = "No hay habitaciones disponibles en la fecha seleccionada para alojar la cantidad de huespedes indicados. Recuerde que tiene la opción de reservar varias habitaciones.";

        public const string temporadaA = "alta";
        public const string temporadaB = "baja";
        public const int variableEnCero = 0;
        public const string valorNoValido = "El valor ingresado supera la cantidad de habitaciones disponibles. Ingrese un número valido.";
        public DateTime inicioTemporadaBaja = new DateTime(2021, 9, 1);
        public DateTime finTemporadaBaja = new DateTime(2021, 9, 1).AddMonths(1).AddDays(30);
        public DateTime inicioTemporadaAlta = new DateTime(2021, 11, 1);
        public DateTime finTemporadaAlta = new DateTime(2021, 11, 1).AddMonths(5).AddDays(23);
    }
}
