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
    public class ReservacionApplicationServices : IReservacionApplication
    {
        private readonly IReservacionDomain reservacionDomain;
        private readonly IMapper mapper;

        public ReservacionApplicationServices(IReservacionDomain reservacionDomain, IMapper mapper)
        {
            this.reservacionDomain = reservacionDomain;
            this.mapper = mapper;
        }

        public ReservacionViewModel GetReservaById(int id)
        {
            return reservacionDomain.GetReservaById(id);
        }

        public IEnumerable<ReservacionViewModel> GetReservaciones()
        {
            return reservacionDomain.GetReservaciones();
        }
    }
}
