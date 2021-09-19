using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class TarifasDomainServices : ITarifasDomain
    {
        private readonly ITarifasRepository tarifasRepository;
        private readonly IMapper mapper;

        public TarifasDomainServices(ITarifasRepository tarifasRepository, IMapper mapper)
        {
            this.tarifasRepository = tarifasRepository;
            this.mapper = mapper;
        }

        public async Task<Rates> GetTarifaById(int id)
        {
            var rate = tarifasRepository.GetTarifaById(id);

            var rateById = mapper.Map<Rates>(rate);

            return rateById;
        }

        public async Task<IEnumerable<Rates>> GetTarifas(TarifasQueryFilter filter)
        {
            var allRates = tarifasRepository.GetTarifas();

            var rates = mapper.Map<IEnumerable<Rates>>(allRates);

            if (filter.Temporada != null)
            {
                rates = rates.Where(p => p.Temporada == filter.Temporada);
            }

            if (filter.Valor == 0)
            {
                rates = rates.Where(p => p.Valor == filter.Valor);
            }

            return rates;
        }
    }
}
