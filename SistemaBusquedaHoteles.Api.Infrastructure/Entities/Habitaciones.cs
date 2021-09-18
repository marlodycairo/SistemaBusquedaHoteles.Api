﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Entities
{
    public class Habitaciones
    {
        [Key]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int TipoId { get; set; }
        public int SedeId { get; set; }

        public TipoAlojamiento Tipo { get; set; }
        public Sedes Sede { get; set; }
        
        public Reservacion Reservacion { get; set; }
    }
}
