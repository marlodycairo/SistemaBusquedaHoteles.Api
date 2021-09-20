using System;
using System.Collections.Generic;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int TipoId { get; set; }
        public int SedeId { get; set; }

        public RoomTypeModel RoomTypeModel { get; set; }
        //public LocationsModel LocationModel { get; set; }
        public ReservationsModel ReservationsModel { get; set; }
    }
}
