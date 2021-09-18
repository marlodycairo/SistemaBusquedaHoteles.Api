using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Entities
{
    public class Rooms
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int TipoId { get; set; }
        public int SedeId { get; set; }

        public RoomType RoomType { get; set; }
        public Locations Locations { get; set; }
        
        public Reservation Reservations { get; set; }
    }
}
