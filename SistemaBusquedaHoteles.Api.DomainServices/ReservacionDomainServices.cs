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
            IHabitacionesRepository habitacionesRepository, ITarifasRepository tarifasRepository,
            ITipoAlojamientoRepository alojamientoRepository, ISedesRepository sedesRepository)
        {
            this.reservacionRepository = reservacionRepository;
            this.mapper = mapper;
            this.habitacionesRepository = habitacionesRepository;
            this.tarifasRepository = tarifasRepository;
            this.alojamientoRepository = alojamientoRepository;
            this.sedesRepository = sedesRepository;
        }

        public async Task<Reservations> CreateReservacion(Reservation reservacion)
        {
            await reservacionRepository.CreateReservation(reservacion);
            Reservations reserva = mapper.Map<Reservations>(reservacion);
            return reserva;
        }

        public async Task DeleteReservacion(int id)
        {
            await reservacionRepository.DeleteReservation(id);
        }

        public async Task<Reservations> GetReservationById(int id)
        {
            Reservation reservas = await reservacionRepository.GetReservationById(id);

            Reservations result = mapper.Map<Reservations>(reservas);

            return result;
        }

        public async Task<IEnumerable<Reservations>> GetReservaciones(ReservacionQueryFilter filter)
        {
            IEnumerable<Reservation> reservas = await reservacionRepository.GetAllReservations();
            IEnumerable<Reservations> result = mapper.Map<IEnumerable<Domain.Models.Reservations>>(reservas);

            IEnumerable<Infrastructure.Entities.Rooms> habitaciones = await habitacionesRepository.GetAll();
            IEnumerable<Domain.Models.Room> listaHabitaciones = mapper.Map<IEnumerable<Domain.Models.Room>>(habitaciones);

            IEnumerable<Infrastructure.Entities.Rooms> listHabitaciones = await habitacionesRepository.GetAll();
            IEnumerable<Domain.Models.Room> lista = mapper.Map<IEnumerable<Domain.Models.Room>>(habitaciones);

            IEnumerable<Infrastructure.Entities.Locations> sedes = await sedesRepository.GetSedes();
            IEnumerable<Domain.Models.Locations> lstSedes = mapper.Map<IEnumerable<Domain.Models.Locations>>(sedes);

            List<Reservations> reservaciones = new List<Domain.Models.Reservations>();

            List<Domain.Models.Room> habitacion = new List<Domain.Models.Room>();

            List<Reservations> realizarReserva = new List<Domain.Models.Reservations>();

            if (filter.Ciudad != 0)
            {
                result = result.Where(p => p.SedeId == filter.Ciudad);
            }

            if (filter.Fecha != null)
            {
                ReservacionDomainServices reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository,
                    tarifasRepository, alojamientoRepository, sedesRepository);

                string message = Constants.fechaNoDisponible;

                foreach (Reservations item in result)
                {
                    if (filter.Fecha == item.Fecha || filter.Fecha < item.Fecha)
                    {
                        //Envia un mensaje si la fecha no está disponible.
                        reservaciones.Add(new Domain.Models.Reservations
                        {
                            Fecha = item.Fecha,
                            Response = message
                        });
                        //return reservaciones;
                    }
                }
                //si la fecha esta disponible debe permitirle ver las habitaciones disponibles de la sede seleccionada
                //var disponibilidad = reserva.CalcularHabitacionesDisponibles(filter.Ciudad);
            }

            if (filter.TotalPersonas != 0)
            {
                foreach (Reservations item in result)
                {
                    if (filter.TotalPersonas > item.Locations.CupoMax)
                    {
                        //Envia un mensaje si supera la cantidad de huespedes por habitación
                        reservaciones.Add(new Domain.Models.Reservations
                        {
                            Response = Constants.superaCapacidadMax
                        });
                        //return reservaciones;
                    }
                }
            }

            if (filter.TotalHabitaciones != 0)
            {
                Reservations reservacio = new Domain.Models.Reservations();

                ReservacionDomainServices reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository, tarifasRepository, alojamientoRepository, sedesRepository);

                //var test = reserva.CalcularHabitacionesDisponibles(filter.Ciudad.ToLower());

                result = result.Where(p => p.TotalHabitaciones == filter.TotalHabitaciones);
            }

            if (filter.SeleccionarTipoHabitacion != 0)
            {
                //Consultar tarifas segun tipo de habitacion elegido
                ReservacionDomainServices reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository,
                    tarifasRepository, alojamientoRepository, sedesRepository);

                IEnumerable<Reservations> query = from p in lista
                                                  join r in result
                                                  on p.RoomType.Id equals r.RoomType.Id
                                                  where p.RoomType.Id == filter.SeleccionarTipoHabitacion
                                                  where r.Locations.Id == filter.Ciudad
                                                  where p.Estado == Constants.message
                                                  select r;

                foreach (Reservations item in query)
                {
                    reservaciones.Add(new Domain.Models.Reservations()
                    {
                        Fecha = item.Fecha,
                        SedeId = item.SedeId,
                        TipoAlojamientoId = item.TipoAlojamientoId
                    });
                }
                double pruebas = reserva.TarifasDisponibles(filter.Fecha, filter.SeleccionarTipoHabitacion);

                double totalAPagar = filter.TotalHabitaciones * pruebas;
            }
            return result;
        }

        public async Task<Reservation> UpdateReservacion(Reservations reservacion)
        {
            var reservas = mapper.Map<Reservation>(reservacion);

            var reservationUpdate = await reservacionRepository.UpdateReservation(reservas);

            return reservationUpdate;
        }

        public double TarifasDisponibles(DateTime? fecha, int tipoHabitacion)
        {
            double valorHabitacion = 0;

            Task<IEnumerable<Reservation>> reservaciones = reservacionRepository.GetAllReservations();
            IEnumerable<Reservations> result = mapper.Map<IEnumerable<Domain.Models.Reservations>>(reservaciones);

            IEnumerable<Infrastructure.Entities.Rooms> habitaciones = habitacionesRepository.GetAll();
            IEnumerable<Domain.Models.Room> listaHabitaciones =  mapper.Map<IEnumerable<Domain.Models.Room>>(habitaciones);

            IEnumerable<Infrastructure.Entities.Rates> tarifas = tarifasRepository.GetTarifas();
            IEnumerable<Domain.Models.Rates> listaTarifas = mapper.Map<IEnumerable<Domain.Models.Rates>>(tarifas);

            IEnumerable<Infrastructure.Entities.RoomType> tipos = alojamientoRepository.GetAlojamientos();
            IEnumerable<Domain.Models.RoomType> alojamientos = mapper.Map<IEnumerable<Domain.Models.RoomType>>(tipos);

            IEnumerable<Infrastructure.Entities.Locations> sedes = sedesRepository.GetSedes();
            IEnumerable<Domain.Models.Locations> lstSedes = mapper.Map<IEnumerable<Domain.Models.Locations>>(sedes);


            //Fecha inicio temporada baja meses Septiembre 1 hasta Octubre 30
            DateTime fInicioBaj2 = new DateTime(2021, 9, 1);

            //Temporada Baja meses Septiembre - Octubre
            DateTime tBaja2 = new DateTime(2021, 9, 1).AddMonths(1).AddDays(31);

            //Fecha inicio temporada baja meses Abril 22 hasta 20 de junio
            DateTime fInicioBaj1 = new DateTime(2022, 4, 21);

            //Temporada Baja Abril + Mayo + hasta el 22 de junio +Septiembre a octubre
            DateTime tBaja1 = new DateTime(2022, 4, 22).AddMonths(2);

            IEnumerable<Reservations> query = (from p in listaHabitaciones
                                               join reservas in result on p.RoomType.Nombre equals reservas.RoomType.Nombre
                                               where p.TipoId == tipoHabitacion
                                               select reservas);

            foreach (Reservations item in query)
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
            Task<IEnumerable<Reservation>> reservaciones = reservacionRepository.GetAllReservations();
            IEnumerable<Reservations> result = mapper.Map<IEnumerable<Domain.Models.Reservations>>(reservaciones);

            IEnumerable<Infrastructure.Entities.Rooms> habitaciones = habitacionesRepository.GetAll();
            IEnumerable<Domain.Models.Room> listaHabitaciones = mapper.Map<IEnumerable<Domain.Models.Room>>(habitaciones);

            IEnumerable<Infrastructure.Entities.Locations> sedes = sedesRepository.GetSedes();
            IEnumerable<Domain.Models.Locations> listadoSedes = mapper.Map<IEnumerable<Domain.Models.Locations>>(sedes);

            int totalHabitacionesDisponibles = Constants.totalHabitacionesDisponibles;
            int totalOcupadas = Constants.totalOcupadas;
            int totalDisponibles = Constants.totalDisponibles;

            foreach (Reservations item in result)
            {
                if (item.Locations.Id == ciudad)
                {
                    totalOcupadas++;
                }
            }

            IEnumerable<Reservations> tipos = from p in listaHabitaciones
                                              join s in result
                                              on p.RoomType.Nombre equals s.RoomType.Nombre
                                              select s;

            foreach (Reservations item in tipos)
            {
                if (item.Locations.Id == ciudad && item.Rooms.Estado == Constants.message)
                {
                    totalDisponibles++;
                }
            }

            //cantidad de habitaciones ocupadas por sede
            IEnumerable<int> totalPorSede = (from p in result
                                             where p.Locations.Id == ciudad
                                             select p.Locations.TotalHabitaciones);

            totalHabitacionesDisponibles = totalPorSede.Count() - totalOcupadas;

            return totalHabitacionesDisponibles;
        }

        public DateTime ValidarFechasDisponibles(DateTime? fecha)
        {
            Task<IEnumerable<Reservation>> reservaciones = reservacionRepository.GetAllReservations();
            IEnumerable<Reservations> result = mapper.Map<IEnumerable<Domain.Models.Reservations>>(reservaciones);

            string message = Constants.superaCapacidadMax + $"{ fecha }";

            foreach (Reservations item in result)
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
