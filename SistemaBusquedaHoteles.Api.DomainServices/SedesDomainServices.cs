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
    public class SedesDomainServices : ISedesDomain
    {
        private readonly ISedesRepository sedesRepository;
        private readonly IMapper mapper;

        public SedesDomainServices(ISedesRepository sedesRepository, IMapper mapper)
        {
            this.sedesRepository = sedesRepository;
            this.mapper = mapper;
        }

        public SedesViewModel GetSedeById(int id)
        {
            var sede = sedesRepository.GetSedeById(id);

            var result = mapper.Map<SedesViewModel>(sede);

            return result;
        }

        public IEnumerable<SedesViewModel> GetSedes()
        {
            var sedes = sedesRepository.GetSedes();

            var result = mapper.Map<IEnumerable<SedesViewModel>>(sedes);

            return result;
        }
    }
}
