using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class ReservationRoomModel
    {
        public int ReservationsId { get; set; }
        public int RoomsId { get; set; }

        public string Response { get; set; }

        public ReservationsModel ReservationModel { get; set; }
        public RoomModel RoomsModel { get; set; }
    }
}
