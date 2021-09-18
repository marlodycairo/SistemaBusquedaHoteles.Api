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

        public Rates GetTarifaById(int id)
        {
            var tarifa = tarifasRepository.GetTarifaById(id);

            var result = mapper.Map<Rates>(tarifa);

            return result;
        }

        public IEnumerable<Rates> GetTarifas(TarifasQueryFilter filter)
        {
            var tarifas = tarifasRepository.GetTarifas();

            var result = mapper.Map<IEnumerable<Rates>>(tarifas);

            if (filter.Temporada != null)
            {
                //rango de fechas
                //temporada alta/baja


                result = result.Where(p => p.Temporada == filter.Temporada);
            }

            if (filter.Valor == 0)
            {
                //precio varía segun temporada y tipo alojamiento
                result = result.Where(p => p.Valor == filter.Valor);
            }

            return result;
        }
    }
}
