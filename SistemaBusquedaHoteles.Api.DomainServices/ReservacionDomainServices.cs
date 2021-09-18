using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Helpers.Constants;
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
        private readonly IHabitacionesRepository habitacionesRepository;
        private readonly ITarifasRepository tarifasRepository;
        private readonly ITipoAlojamientoRepository alojamientoRepository;
        private readonly ISedesRepository sedesRepository;

        public ReservacionDomainServices(IReservacionRepository reservacionRepository, IMapper mapper, 
            IHabitacionesRepository habitacionesRepository,
            ITarifasRepository tarifasRepository, ITipoAlojamientoRepository alojamientoRepository,
            ISedesRepository sedesRepository)
        {
            this.reservacionRepository = reservacionRepository;
            this.mapper = mapper;
            this.habitacionesRepository = habitacionesRepository;
            this.tarifasRepository = tarifasRepository;
            this.alojamientoRepository = alojamientoRepository;
            this.sedesRepository = sedesRepository;
        }

        public Domain.Models.Reservation CreateReservacion(Infrastructure.Entities.Reservation reservacion)
        {
            reservacionRepository.CreateReservacion(reservacion);

            var reserva = mapper.Map<Domain.Models.Reservation>(reservacion);
            return reserva;
        }

        public void DeleteReservacion(int id)
        {
            reservacionRepository.DeleteReservacion(id);
        }

        public Domain.Models.Reservation GetReservaById(int id)
        {
            var reservas = reservacionRepository.GetReservaById(id);

            var result = mapper.Map<Domain.Models.Reservation>(reservas);

            return result;
        }

        public IEnumerable<Domain.Models.Reservation> GetReservaciones(ReservacionQueryFilter filter)
        {
            //listado de reservaciones
            var reservas = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<Domain.Models.Reservation>>(reservas);

            //listado de habitaciones
            var habitaciones = habitacionesRepository.GetAll();
            var listaHabitaciones = mapper.Map<IEnumerable<Domain.Models.Rooms>>(habitaciones);

            var listHabitaciones = habitacionesRepository.GetAll();
            var lista = mapper.Map<IEnumerable<Domain.Models.Rooms>>(habitaciones);

            var sedes = sedesRepository.GetSedes();
            var lstSedes = mapper.Map<IEnumerable<Domain.Models.Locations>>(sedes);

            var reservaciones = new List<Domain.Models.Reservation>();

            var habitacion = new List<Domain.Models.Rooms>();

            var realizarReserva = new List<Domain.Models.Reservation>();

            if (filter.Ciudad != 0)
            {
                result = result.Where(p => p.SedeId == filter.Ciudad);
            }

            if (filter.Fecha != null)
            {
                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository,
                    tarifasRepository, alojamientoRepository, sedesRepository);

                var message = Constants.fechaNoDisponible;

                foreach (var item in result)
                {
                    if (filter.Fecha == item.Fecha || filter.Fecha < item.Fecha)
                    {
                        //Envia un mensaje si la fecha no está disponible.
                        reservaciones.Add(new Domain.Models.Reservation
                        {
                            Fecha = item.Fecha,
                            Respuesta = message
                        });
                        //return reservaciones;
                    }
                }
                //si la fecha esta disponible debe permitirle ver las habitaciones disponibles de la sede seleccionada
                //var disponibilidad = reserva.CalcularHabitacionesDisponibles(filter.Ciudad);
            }

            if (filter.TotalPersonas != 0)
            {
                foreach (var item in result)
                {
                    if (filter.TotalPersonas > item.Locations.CupoMax)
                    {
                        //Envia un mensaje si supera la cantidad de huespedes por habitación
                        reservaciones.Add(new Domain.Models.Reservation
                        {
                            Respuesta = Constants.superaCapacidadMax
                        });
                        //return reservaciones;
                    }
                }
            }

            if (filter.TotalHabitaciones != 0)
            {
                var reservacio = new Domain.Models.Reservation();

                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository, tarifasRepository, alojamientoRepository, sedesRepository);

                //var test = reserva.CalcularHabitacionesDisponibles(filter.Ciudad.ToLower());

                result = result.Where(p => p.TotalHabitaciones == filter.TotalHabitaciones);
            }

            if (filter.SeleccionarTipoHabitacion != 0)
            {
                //Consultar tarifas segun tipo de habitacion elegido
                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository,
                    tarifasRepository, alojamientoRepository, sedesRepository);

                var query = from p in lista
                            join r in result
                            on p.RoomType.Id equals r.RoomType.Id
                            where p.RoomType.Id == filter.SeleccionarTipoHabitacion
                            where r.Locations.Id == filter.Ciudad
                            where p.Estado == Constants.message
                            select r;

                foreach (var item in query)
                {
                    reservaciones.Add(new Domain.Models.Reservation()
                    {
                        Fecha = item.Fecha,
                        SedeId = item.SedeId,
                        TipoAlojamientoId = item.TipoAlojamientoId
                    });
                }
                var pruebas = reserva.TarifasDisponibles(filter.Fecha, filter.SeleccionarTipoHabitacion);

                double totalAPagar = filter.TotalHabitaciones * pruebas;
            }
            return result;
        }

        public Domain.Models.Reservation UpdateReservacion(Domain.Models.Reservation reservacion)
        {
            var reservas = mapper.Map<Infrastructure.Entities.Reservation>(reservacion);

            reservacionRepository.UpdateReservacion(reservas);

            return reservacion;
        }

        public double TarifasDisponibles(DateTime? fecha, int tipoHabitacion)
        {
            double valorHabitacion = 0;

            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<Domain.Models.Reservation>>(reservaciones);

            var habitaciones = habitacionesRepository.GetAll();
            var listaHabitaciones = mapper.Map<IEnumerable<Domain.Models.Rooms>>(habitaciones);

            var tarifas = tarifasRepository.GetTarifas();
            var listaTarifas = mapper.Map<IEnumerable<Domain.Models.Rates>>(tarifas);

            var tipos = alojamientoRepository.GetAlojamientos();
            var alojamientos = mapper.Map<IEnumerable<Domain.Models.RoomType>>(tipos);

            var sedes = sedesRepository.GetSedes();
            var lstSedes = mapper.Map<IEnumerable<Domain.Models.Locations>>(sedes);


            //Fecha inicio temporada baja meses Septiembre 1 hasta Octubre 30
            var fInicioBaj2 = new DateTime(2021, 9, 1);

            //Temporada Baja meses Septiembre - Octubre
            DateTime tBaja2 = new DateTime(2021, 9, 1).AddMonths(1).AddDays(31);

            //Fecha inicio temporada baja meses Abril 22 hasta 20 de junio
            var fInicioBaj1 = new DateTime(2022, 4, 21);

            //Temporada Baja Abril + Mayo + hasta el 22 de junio +Septiembre a octubre
            DateTime tBaja1 = new DateTime(2022, 4, 22).AddMonths(2);

            var query = (from p in listaHabitaciones
                        join reservas in result on p.RoomType.Nombre equals reservas.RoomType.Nombre
                        where p.TipoId == tipoHabitacion
                        select reservas);

            foreach (var item in query)
            {
                if (fecha >= fInicioBaj2 && fecha <= tBaja2 || fecha >= fInicioBaj1 && fecha <= tBaja1)
                {
                    valorHabitacion = item.Rates.Valor;
                }
                else
                {
                    item.Rates.Temporada = Constants.confirmartemporada;
                }
            }
            return valorHabitacion;
        }

        public int CalcularHabitacionesDisponibles(int ciudad)
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<Domain.Models.Reservation>>(reservaciones);

            var habitaciones = habitacionesRepository.GetAll();
            var listaHabitaciones = mapper.Map<IEnumerable<Domain.Models.Rooms>>(habitaciones);

            var sedes = sedesRepository.GetSedes();
            var listadoSedes = mapper.Map<IEnumerable<Domain.Models.Locations>>(sedes);

            int totalHabitacionesDisponibles = Constants.totalHabitacionesDisponibles;
            int totalOcupadas = Constants.totalOcupadas;
            int totalDisponibles = Constants.totalDisponibles;

            foreach (var item in result)
            {
                if (item.Locations.Id == ciudad)
                {
                    totalOcupadas++;
                }
            }

            var tipos = from p in listaHabitaciones
                        join s in result
                        on p.RoomType.Nombre equals s.RoomType.Nombre
                        select s;

            foreach (var item in tipos)
            {
                if (item.Locations.Id == ciudad && item.HabitacionesModel.Estado == Constants.message)
                {
                    totalDisponibles++;
                }
            }

            //cantidad de habitaciones ocupadas por sede
            var totalPorSede = (from p in result
                                where p.Locations.Id == ciudad
                                select p.Locations.TotalHabitaciones);

            totalHabitacionesDisponibles = totalPorSede.Count() - totalOcupadas;

            return totalHabitacionesDisponibles;
        }

        public DateTime ValidarFechasDisponibles(DateTime? fecha)
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<Domain.Models.Reservation>>(reservaciones);

            var message = Constants.superaCapacidadMax + $"{ fecha }";

            foreach (var item in result)
            {
                if (item.Fecha != fecha)
                {
                    return fecha.Value;
                }
                message.ToString();
            }
            return fecha.Value;
        }
    }
}
