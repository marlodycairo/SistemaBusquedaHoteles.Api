using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Entities
{
    public class Reservation
    {
        [Key]
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
        public int HabitacionId { get; set; }

        public Location Locations { get; set; }
        //public RoomTypes RoomType { get; set; }

        //public Rate Rates { get; set; }
        public Customer Customers { get; set; }
        //public Rooms Room { get; set; }
    }
}
