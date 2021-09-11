using System;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class HabitacionesViewModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int TipoId { get; set; }
        public int SedeId { get; set; }
        public int TarifaId { get; set; }
        public int ReservaId { get; set; }

        public TipoAlojamientoViewModel TipoAlojamientos { get; set; }
        public SedesViewModel Sedes { get; set; }
        public TarifasViewModel Tarifa { get; set; }
        public ReservacionViewModel ReservaModel { get; set; }
    }
}
