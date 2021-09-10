using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.ApplicationServices
{
    public class TarifasApplicationServices : ITarifasApplication
    {
        private readonly ITarifasDomain tarifasDomain;

        public TarifasApplicationServices(ITarifasDomain tarifasDomain)
        {
            this.tarifasDomain = tarifasDomain;
        }

        public TarifasViewModel GetTarifaById(int id)
        {
            return tarifasDomain.GetTarifaById(id);
        }

        public IEnumerable<TarifasViewModel> GetTarifas()
        {
            return tarifasDomain.GetTarifas();
        }
    }
}
