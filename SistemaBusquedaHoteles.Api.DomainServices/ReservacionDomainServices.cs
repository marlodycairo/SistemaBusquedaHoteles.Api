
using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
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

        public ReservacionViewModel CreateReservacion(Reservacion reservacion)
        {
            reservacionRepository.CreateReservacion(reservacion);

            var reserva = mapper.Map<ReservacionViewModel>(reservacion);
            return reserva;
        }

        public void DeleteReservacion(int id)
        {
            reservacionRepository.DeleteReservacion(id);
        }

        public ReservacionViewModel GetReservaById(int id)
        {
            var reservas = reservacionRepository.GetReservaById(id);

            var result = mapper.Map<ReservacionViewModel>(reservas);
            
            return result;
        }

        public IEnumerable<ReservacionViewModel> GetReservaciones(ReservacionQueryFilter filter)
        {
            var reservas = reservacionRepository.GetReservaciones();

            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservas);

            if (filter.Ciudad != null)
            {
                result = result.Where(p => p.SedesModel.Ciudad.ToLower() == filter.Ciudad.ToLower());
            }

            if (filter.Fecha != null)
            {
                result = result.Where(p => p.Fecha.ToShortDateString() == filter.Fecha?.ToShortDateString());
            }

            if (filter.TotalPersonas != 0)
            {
                result = result.Where(p => p.TotalPersonas == filter.TotalPersonas);
            }

            if (filter.TotalHabitaciones != 0)
            {
                result = result.Where(p => p.TotalHabitaciones == filter.TotalHabitaciones);
            }

            if (filter.ValorTotal != 0)
            {
                result = result.Where(p => p.ValorTotal == filter.ValorTotal);
            }

            if (filter.TipoAlojamiento != null)
            {
                result = result.Where(p => p.TipoAlojamientoModel.Nombre.ToLower() == filter.TipoAlojamiento.ToLower());
            }

            if (filter.Tarifa != 0)
            {
                result = result.Where(p => p.TarifasModel.Valor == filter.Tarifa);
            }

            if (filter.IDCliente != null)
            {
                result = result.Where(p => p.ClienteModel.IDCliente.ToLower().Trim() == filter.IDCliente.ToLower().Trim());
            }

            return result;
        }

        public ReservacionViewModel UpdateReservacion(ReservacionViewModel reservacion)
        {
            var reservas = mapper.Map<Reservacion>(reservacion);

            reservacionRepository.UpdateReservacion(reservas);

            return reservacion;
        }
    }
}
