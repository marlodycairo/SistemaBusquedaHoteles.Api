using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Ciudad { get; set; }
        public int CupoMax { get; set; }
        public int TotalHabitaciones { get; set; }

        //public Reservation Reservations { get; set; }
        //public Rooms Room { get; set; }
    }
}
