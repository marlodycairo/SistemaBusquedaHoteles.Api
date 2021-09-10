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

        public HabitacionesViewModel HabitacionesModel { get; set; }
    }
}
