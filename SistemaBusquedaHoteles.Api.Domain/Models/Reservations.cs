﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class Reservations
    {
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

        public string Response { get; set; }

        public Locations Locations { get; set; }
        public RoomType RoomType { get; set; }
        public Rates Rates { get; set; }
        public Customers Customer { get; set; }
        public Rooms Rooms { get; set; }
    }
}
