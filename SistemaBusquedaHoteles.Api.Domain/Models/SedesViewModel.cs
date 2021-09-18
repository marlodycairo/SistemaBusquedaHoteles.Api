﻿using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class SedesViewModel
    {
        public int Id { get; set; }
        public string Ciudad { get; set; }
        public int CupoMax { get; set; }
        public int TotalHabitaciones { get; set; }

        public Reservation ReservacionView { get; set; }
        public HabitacionesViewModel HabitacionesView { get; set; }
    }
}
