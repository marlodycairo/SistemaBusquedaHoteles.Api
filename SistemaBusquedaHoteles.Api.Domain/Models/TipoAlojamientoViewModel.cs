using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class TipoAlojamientoViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ReservacionViewModel ReservacionView { get; set; }
        public HabitacionesViewModel HabitacionesView { get; set; }
    }
}
