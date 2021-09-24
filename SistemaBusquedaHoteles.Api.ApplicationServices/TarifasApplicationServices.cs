using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.ApplicationServices
{
    public class TarifasApplicationServices : IRatesApplication
    {
        private readonly IRatesDomain tarifasDomain;

        public TarifasApplicationServices(IRatesDomain tarifasDomain)
        {
            this.tarifasDomain = tarifasDomain;
        }

        public async Task<RatesModel> GetTarifaById(int id)
        {
            return await tarifasDomain.GetTarifaById(id);
        }

        public async Task<IEnumerable<RatesModel>> GetTarifas()
        {
            return await tarifasDomain.GetTarifas();
        }
    }
}
