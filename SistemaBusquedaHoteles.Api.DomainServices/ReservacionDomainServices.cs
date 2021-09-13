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

            DateTime date = (DateTime)filter.Fecha;

            ReservacionViewModel testModel = new ReservacionViewModel();

            List<ReservacionViewModel> testList = new List<ReservacionViewModel>();

            if (filter.Ciudad != null)
            {                
                result = result.Where(p => p.SedesModel.Ciudad.ToLower() == filter.Ciudad.ToLower());
            }

            if (filter.Fecha != null)
            {
                var message = $"No hay una habitación disponible en la fecha { filter.Fecha }";
                
                foreach (var item in result)
                {
                    if (Equals(filter.Fecha, item.Fecha))
                    {
                        var test = item.Respuesta;
                        item.Respuesta = message;

                        var testFecha = item.Fecha;
                        item.Fecha = date;

                        testList.Add(new ReservacionViewModel() 
                        {
                            Fecha = item.Fecha,
                            Respuesta = item.Respuesta
                        });
                        return testList;
                    }
                }
            }

            if (filter.TotalPersonas != 0)
            {
                var message = $"En este momento no contamos con habitaciones con esta capacidad. Considere la posibilidad de reservar varias habitaciones.";
                var test = 0;

                foreach (var item in result)
                {
                    if (filter.TotalPersonas < item.SedesModel.CupoMax)
                    {

                    }
                    else
                    {
                        item.Fecha = date;
                        //test = item.SedesModel.CupoMax;
                        item.Respuesta = message;
                        testList.Add(new ReservacionViewModel() 
                        {
                            Fecha = item.Fecha,
                            Respuesta = item.Respuesta
                        });
                        return testList;
                    }
                }

                result = result.Where(p => p.SedesModel.CupoMax <= filter.TotalPersonas);
            }

            if (filter.TotalHabitaciones != 0)
            {


                result = result.Where(p => p.TotalHabitaciones == filter.TotalHabitaciones);
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
