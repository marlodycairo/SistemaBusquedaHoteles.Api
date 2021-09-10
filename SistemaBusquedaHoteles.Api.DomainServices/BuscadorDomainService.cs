using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class BuscadorDomainService : IBuscadorDomain
    {
        private readonly IBuscadorRepository reservaRepository;
        private readonly IMapper mapper;

        public BuscadorDomainService(IBuscadorRepository reservaRepository, IMapper mapper)
        {
            this.reservaRepository = reservaRepository;
            this.mapper = mapper;
        }

        public IEnumerable<HabitacionesViewModel> ConsultarAlojamiento(string buscar)
        {
            var habitaciones = reservaRepository.ConsultarAlojamiento(buscar);

            var result = mapper.Map<IEnumerable<HabitacionesViewModel>>(habitaciones);

            return result;
        }
    }
}
