using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface ITarifasDomain
    {
        Task<IEnumerable<Rates>> GetTarifas(TarifasQueryFilter filter);
        Task<Rates> GetTarifaById(int id);
    }
}
