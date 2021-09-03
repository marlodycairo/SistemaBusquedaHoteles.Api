using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class SedesDomainServices : ISedesDomain
    {
        private readonly ISedesDomain sedesDomain;
        private readonly IMapper mapper;

        public SedesDomainServices(ISedesDomain sedesDomain, IMapper mapper)
        {
            this.sedesDomain = sedesDomain;
            this.mapper = mapper;
        }

        public SedesViewModel GetSedeById(int id)
        {
            return sedesDomain.GetSedeById(id);
        }

        public IEnumerable<SedesViewModel> GetSedes()
        {
            return sedesDomain.GetSedes();
        }
    }
}
