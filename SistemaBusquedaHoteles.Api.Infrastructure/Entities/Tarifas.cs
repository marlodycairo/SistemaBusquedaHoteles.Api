using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Entities
{
    public class Tarifas
    {
        [Key]
        public int Id { get; set; }
        public double Valor { get; set; }
        public string Temporada { get; set; }

        public int TipoAlojamientoId { get; set; }
        public TipoAlojamiento Alojamiento { get; set; }
    }
}
