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
