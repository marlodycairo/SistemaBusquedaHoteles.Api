using System;
using System.Collections.Generic;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string Estado { get; set; }
        public int TipoId { get; set; }
        public int SedeId { get; set; }
        public string Response { get; set; }
        public double PrecioHabitacion { get; set; }
    }
}
