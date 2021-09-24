using AutoMapper;
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
    public class SedesApplicationService : ILocationApplication
    {
        private readonly ILocationDomain sedesDomain;
        private readonly IMapper mapper;

        public SedesApplicationService(ILocationDomain sedesDomain, IMapper mapper)
        {
            this.sedesDomain = sedesDomain;
            this.mapper = mapper;
        }

        public async Task<LocationsModel> GetSedeById(int id)
        {
            return await sedesDomain.GetSedeById(id);
        }

        public async Task<IEnumerable<LocationsModel>> GetSedes()
        {
            return await sedesDomain.GetSedes();
        }
    }
}
