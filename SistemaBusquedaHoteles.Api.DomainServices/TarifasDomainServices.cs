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

        public async Task<RatesModel> GetTarifaById(int id)
        {
            var rate = await tarifasRepository.GetTarifaById(id);

            var rateById = mapper.Map<RatesModel>(rate);

            return rateById;
        }

        public async Task<IEnumerable<RatesModel>> GetTarifas()
        {
            var allRates = await tarifasRepository.GetTarifas();
            var rates = mapper.Map<IEnumerable<RatesModel>>(allRates);
            return rates;
        }
    }
}
