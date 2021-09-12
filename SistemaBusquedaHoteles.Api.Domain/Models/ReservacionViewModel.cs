using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class ReservacionViewModel
    {
        public int Id { get; set; }
        public string IDReservacion { get; set; }
        public DateTime Fecha { get; set; }
        public int TotalPersonas { get; set; }
        public int TotalHabitaciones { get; set; }
        public double ValorTotal { get; set; }
        public int SedeId { get; set; }
        public int TipoAlojamientoId { get; set; }
        public int TarifaId { get; set; }
        public int ClienteId { get; set; }

        public SedesViewModel SedesModel { get; set; }
        public TipoAlojamientoViewModel TipoAlojamientoModel { get; set; }
        public TarifasViewModel TarifasModel { get; set; }
        public ClienteViewModel ClienteModel { get; set; }
    }
}
