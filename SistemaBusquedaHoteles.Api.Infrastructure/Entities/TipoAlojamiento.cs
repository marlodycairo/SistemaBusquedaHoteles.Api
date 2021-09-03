using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Entities
{
    public class TipoAlojamiento
    {
        [ScaffoldColumn(false)]
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
