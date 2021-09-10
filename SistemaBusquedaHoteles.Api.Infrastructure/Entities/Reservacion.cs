using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Entities
{
    public class Reservacion
    {
        [Key]
        public int Id { get; set; }
        public string IDReservacion { get; set; }
        public DateTime Fecha { get; set; }

        public Habitaciones Habitacion { get; set; }
    }
}
