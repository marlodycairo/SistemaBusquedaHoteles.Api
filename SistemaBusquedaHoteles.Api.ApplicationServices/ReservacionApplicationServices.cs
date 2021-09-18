﻿using AutoMapper;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
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

        public Domain.Models.Reservation CreateReservacion(Domain.Models.Reservation reservacion)
        {
            var objReservacion = mapper.Map<Infrastructure.Entities.Reservation>(reservacion);
            var reservaciones = reservacionDomain.CreateReservacion(objReservacion);

            return reservaciones;
        }

        public void DeleteReservacion(int id)
        {
            reservacionDomain.DeleteReservacion(id);
        }

        public Domain.Models.Reservation GetReservaById(int id)
        {
            return reservacionDomain.GetReservaById(id);
        }

        public IEnumerable<Domain.Models.Reservation> GetReservaciones(ReservacionQueryFilter filter)
        {
            return reservacionDomain.GetReservaciones(filter);
        }

        public Domain.Models.Reservation UpdateReservacion(Domain.Models.Reservation reservacion)
        {
            return reservacionDomain.UpdateReservacion(reservacion);
        }
    }
}
