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
    public class LocationDomainServices : ILocationDomain
    {
        private readonly ILocationRepository sedesRepository;
        private readonly IMapper mapper;

        public LocationDomainServices(ILocationRepository sedesRepository, IMapper mapper)
        {
            this.sedesRepository = sedesRepository;
            this.mapper = mapper;
        }

        public async Task<LocationsModel> GetSedeById(int id)
        {
            var location = await sedesRepository.GetSedeById(id);

            var locationMapper = mapper.Map<LocationsModel>(location);

            return locationMapper;
        }

        public async Task<IEnumerable<LocationsModel>> GetSedes()
        {
            var locations = await sedesRepository.GetSedes();

            var locationMapper = mapper.Map<IEnumerable<LocationsModel>>(locations);

            return locationMapper;
        }
    }
}
