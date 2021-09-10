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
    public class ReservacionDomainServices : IReservacionDomain
    {
        private readonly IReservacionRepository reservacionRepository;
        private readonly IMapper mapper;

        public ReservacionDomainServices(IReservacionRepository reservacionRepository, IMapper mapper)
        {
            this.reservacionRepository = reservacionRepository;
            this.mapper = mapper;
        }

        public ReservacionViewModel GetReservaById(int id)
        {
            var reservas = reservacionRepository.GetReservaById(id);

            var result = mapper.Map<ReservacionViewModel>(reservas);
            
            return result;
        }

        public IEnumerable<ReservacionViewModel> GetReservaciones()
        {
            var reservas = reservacionRepository.GetReservaciones();

            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservas);

            return result;
        }
    }
}
