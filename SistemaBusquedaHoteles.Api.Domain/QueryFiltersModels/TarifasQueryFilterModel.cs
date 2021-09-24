using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.QueryFilters
{
    public class TarifasQueryFilterModel
    {
        public double Valor { get; set; }
        public string Temporada { get; set; }
    }
}
