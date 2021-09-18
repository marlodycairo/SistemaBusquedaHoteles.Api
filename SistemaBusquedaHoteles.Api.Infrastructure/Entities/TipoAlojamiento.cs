﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Entities
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Reservation Reservacion { get; set; }
        public Rooms Habitaciones { get; set; }
    }
}
