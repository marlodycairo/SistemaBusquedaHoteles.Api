using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Reservations Reservation { get; set; }
        public Rooms Rooms { get; set; }
    }
}
