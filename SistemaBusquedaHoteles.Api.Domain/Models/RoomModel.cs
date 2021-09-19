﻿using System;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int TipoId { get; set; }
        public int SedeId { get; set; }

        public RoomTypeModel RoomType { get; set; }
        public LocationsModel Locations { get; set; }
        public ReservationsModel Reservations { get; set; }
    }
}
