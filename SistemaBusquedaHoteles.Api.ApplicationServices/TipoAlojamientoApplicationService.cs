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
    public class TipoAlojamientoApplicationService : ITipoAlojamientoApplication
    {
        private readonly ITipoAlojamientoDomain tipoAlojamientoDomain;
        private readonly IMapper mapper;

        public TipoAlojamientoApplicationService(ITipoAlojamientoDomain tipoAlojamientoDomain, IMapper mapper)
        {
            this.tipoAlojamientoDomain = tipoAlojamientoDomain;
            this.mapper = mapper;
        }

        public TipoAlojamientoViewModel GetAlojamientoById(int id)
        {
            return tipoAlojamientoDomain.GetAlojamientoById(id);
        }

        public IEnumerable<TipoAlojamientoViewModel> GetAlojamientos()
        {
            return tipoAlojamientoDomain.GetAlojamientos();
        }
    }
}
