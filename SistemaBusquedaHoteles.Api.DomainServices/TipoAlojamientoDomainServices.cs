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
    public class TipoAlojamientoDomainServices : ITipoAlojamientoDomain
    {
        private readonly ITipoAlojamientoDomain tipoAlojamientoDomain;

        public TipoAlojamientoDomainServices(ITipoAlojamientoDomain tipoAlojamientoDomain, IMapper mapper)
        {
            this.tipoAlojamientoDomain = tipoAlojamientoDomain;
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
