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

        public async Task<Locations> GetSedeById(int id)
        {
            var location = sedesRepository.GetSedeById(id);

            var locationMapper = mapper.Map<Locations>(location);

            return locationMapper;
        }

        public async Task<IEnumerable<Locations>> GetSedes()
        {
            var locations = sedesRepository.GetSedes();

            var locationMapper = mapper.Map<IEnumerable<Locations>>(locations);

            return locationMapper;
        }
    }
}
