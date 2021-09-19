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
    public class SedesApplicationService : ISedesApplication
    {
        private readonly ISedesDomain sedesDomain;
        private readonly IMapper mapper;

        public SedesApplicationService(ISedesDomain sedesDomain, IMapper mapper)
        {
            this.sedesDomain = sedesDomain;
            this.mapper = mapper;
        }

        public async Task<Locations> GetSedeById(int id)
        {
            return await sedesDomain.GetSedeById(id);
        }

        public async Task<IEnumerable<Locations>> GetSedes()
        {
            return await sedesDomain.GetSedes();
        }
    }
}
