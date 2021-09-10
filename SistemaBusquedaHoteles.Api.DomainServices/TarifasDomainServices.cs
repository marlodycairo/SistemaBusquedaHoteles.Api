using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
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

        public TarifasViewModel GetTarifaById(int id)
        {
            var tarifa = tarifasRepository.GetTarifaById(id);

            var result = mapper.Map<TarifasViewModel>(tarifa);

            return result;
        }

        public IEnumerable<TarifasViewModel> GetTarifas()
        {
            var tarifas = tarifasRepository.GetTarifas();

            var result = mapper.Map<IEnumerable<TarifasViewModel>>(tarifas);

            return result;
        }
    }
}
