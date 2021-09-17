using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class TarifasViewModel
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public string Temporada { get; set; }

        public string TipoHabitacion { get; set; }
        public int CapacidadMaxima { get; set; }
        public int TipoAlojamientoId { get; set; }
        public TipoAlojamientoViewModel AlojamientoModel { get; set; }

        public string Ciudad { get; set; }
        public SedesViewModel SedesView { get; set; }
    }
}
