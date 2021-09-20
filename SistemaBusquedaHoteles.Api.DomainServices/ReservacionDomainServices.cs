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

        public async Task<ReservationsModel> CreateReservacion(Reservation reservacion)
        {
            await reservacionRepository.CreateReservation(reservacion);
            ReservationsModel reserva = mapper.Map<ReservationsModel>(reservacion);
            return reserva;
        }

        public async Task DeleteReservacion(int id)
        {
            await reservacionRepository.DeleteReservation(id);
        }

        public async Task<ReservationsModel> GetReservationById(int id)
        {
            Reservation reservas = await reservacionRepository.GetReservationById(id);

            ReservationsModel result = mapper.Map<ReservationsModel>(reservas);

            return result;
        }

        public async Task<IEnumerable<ReservationsModel>> GetReservaciones(ReservacionQueryFilter filter)
        {
            var reservations = await reservacionRepository.GetAllReservations();
            var allReservations = mapper.Map<IEnumerable<ReservationsModel>>(reservations);

            var rooms = await habitacionesRepository.GetAll();
            var allRooms = mapper.Map<IEnumerable<Domain.Models.RoomModel>>(rooms);

            //var locations = await sedesRepository.GetSedes();
            //var allLocations = mapper.Map<IEnumerable<Domain.Models.LocationsModel>>(locations);
            //List<RoomModel> roomsList = new List<RoomModel>();
            //var reserve = new List<ReservationsModel>();

            var reservationsList = new List<ReservationsModel>();

            if (filter.Ciudad != 0)
            {
                //allReservations.Join(rooms, res => res.SedeId,
                //    ro => ro.SedeId, (res, ro) => new { res, ro }).Where(p => p.ro.SedeId == filter.Ciudad);
                allReservations = allReservations.Where(p => p.SedeId == filter.Ciudad);
            }

            if (filter.Fecha != null)
            {
                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository,
                    tarifasRepository, alojamientoRepository, sedesRepository);

                string message = Constants.fechaNoDisponible;

                foreach (ReservationsModel item in allReservations)
                {
                    if (filter.Fecha == item.Fecha || filter.Fecha < item.Fecha)
                    {
                        //Envia un mensaje si la fecha no está disponible.
                        reservationsList.Add(new ReservationsModel
                        {
                            Fecha = item.Fecha,
                            Responses = message
                        });
                        //return reservaciones;
                    }
                }
                //si la fecha esta disponible debe permitirle ver las habitaciones disponibles de la sede seleccionada
                //var disponibilidad = reserva.CalcularHabitacionesDisponibles(filter.Ciudad);
            }

            if (filter.TotalPersonas != 0)
            {
                foreach (ReservationsModel item in allReservations)
                {
                    //if (filter.TotalPersonas > item.LocationModel.CupoMax)
                    //{
                    //    //Envia un mensaje si supera la cantidad de huespedes por habitación
                    //    reservationsList.Add(new ReservationsModel
                    //    {
                    //        Responses = Constants.superaCapacidadMax
                    //    });
                    //    //return reservaciones;
                    //}
                }
            }

            if (filter.TotalHabitaciones != 0)
            {
                var reservacio = new ReservationsModel();

                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository, tarifasRepository, alojamientoRepository, sedesRepository);

                //var test = reserva.CalcularHabitacionesDisponibles(filter.Ciudad.ToLower());

                allReservations = allReservations.Where(p => p.TotalHabitaciones == filter.TotalHabitaciones);
            }

            if (filter.SeleccionarTipoHabitacion != 0)
            {
                //Consultar tarifas segun tipo de habitacion elegido
                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository,
                    tarifasRepository, alojamientoRepository, sedesRepository);

                //var query = from p in rooms
                //                                  join r in allReservations
                //                                  on p.RoomType.Id equals r.RoomTypesModel.Id
                //                                  where p.RoomType.Id == filter.SeleccionarTipoHabitacion
                //                                  where r.LocationModel.Id == filter.Ciudad
                //                                  where p.Estado == Constants.message
                //                                  select r;

                //foreach (ReservationsModel item in query)
                //{
                //    reservationsList.Add(new Domain.Models.ReservationsModel()
                //    {
                //        Fecha = item.Fecha,
                //        SedeId = item.SedeId,
                //        TipoAlojamientoId = item.TipoAlojamientoId
                //    });
                //}
                //double pruebas = reserva.TarifasDisponibles(filter.Fecha, filter.SeleccionarTipoHabitacion);

                //double totalAPagar = filter.TotalHabitaciones * pruebas;
            }
            return allReservations;
        }

        public async Task<Reservation> UpdateReservacion(ReservationsModel reservacion)
        {
            var reservas = mapper.Map<Reservation>(reservacion);

            var reservationUpdate = await reservacionRepository.UpdateReservation(reservas);

            return reservationUpdate;
        }

        public double TarifasDisponibles(DateTime? fecha, int tipoHabitacion)
        {
            double valorHabitacion = 0;

            var reservaciones = reservacionRepository.GetAllReservations();
            var result = mapper.Map<IEnumerable<Domain.Models.ReservationsModel>>(reservaciones);

            var habitaciones = habitacionesRepository.GetAll();
            var listaHabitaciones =  mapper.Map<IEnumerable<Domain.Models.RoomModel>>(habitaciones);

            var tarifas = tarifasRepository.GetTarifas();
            var listaTarifas = mapper.Map<IEnumerable<Domain.Models.RatesModel>>(tarifas);

            var tipos = alojamientoRepository.GetAlojamientos();
            var alojamientos = mapper.Map<IEnumerable<Domain.Models.RoomTypeModel>>(tipos);

            var sedes = sedesRepository.GetSedes();
            var lstSedes = mapper.Map<IEnumerable<Domain.Models.LocationsModel>>(sedes);


            //Fecha inicio temporada baja meses Septiembre 1 hasta Octubre 30
            DateTime fInicioBaj2 = new DateTime(2021, 9, 1);

            //Temporada Baja meses Septiembre - Octubre
            DateTime tBaja2 = new DateTime(2021, 9, 1).AddMonths(1).AddDays(31);

            //Fecha inicio temporada baja meses Abril 22 hasta 20 de junio
            DateTime fInicioBaj1 = new DateTime(2022, 4, 21);

            //Temporada Baja Abril + Mayo + hasta el 22 de junio +Septiembre a octubre
            DateTime tBaja1 = new DateTime(2022, 4, 22).AddMonths(2);

            IEnumerable<ReservationsModel> query = (from p in listaHabitaciones
                                               join reservas in result on p.RoomTypeModel.Nombre equals reservas.RoomTypesModel.Nombre
                                               where p.TipoId == tipoHabitacion
                                               select reservas);

            foreach (ReservationsModel item in query)
            {
                if (fecha >= fInicioBaj2 && fecha <= tBaja2 || fecha >= fInicioBaj1 && fecha <= tBaja1)
                {
                    valorHabitacion = item.RateModel.Valor;
                }
                else
                {
                    item.RateModel.Temporada = Constants.confirmartemporada;
                }
            }
            return valorHabitacion;
        }

        public int CalcularHabitacionesDisponibles(int ciudad)
        {
            var reservaciones = reservacionRepository.GetAllReservations();
            var result = mapper.Map<IEnumerable<Domain.Models.ReservationsModel>>(reservaciones);

            var habitaciones = habitacionesRepository.GetAll();
            var listaHabitaciones = mapper.Map<IEnumerable<Domain.Models.RoomModel>>(habitaciones);

            var sedes = sedesRepository.GetSedes();
            var listadoSedes = mapper.Map<IEnumerable<Domain.Models.LocationsModel>>(sedes);

            //int totalHabitacionesDisponibles = Constants.totalHabitacionesDisponibles;
            //int totalOcupadas = Constants.totalOcupadas;
            //int totalDisponibles = Constants.totalDisponibles;

            foreach (ReservationsModel item in result)
            {
                //if (item.LocationModel.Id == ciudad)
                //{
                //    totalOcupadas++;
                //}
            }

            IEnumerable<ReservationsModel> tipos = from p in listaHabitaciones
                                              join s in result
                                              on p.RoomTypeModel.Nombre equals s.RoomTypesModel.Nombre
                                              select s;

            //foreach (ReservationsModel item in tipos)
            //{
            //    if (item.LocationModel.Id == ciudad && item.RoomsModel.Estado == Constants.message)
            //    {
            //        totalDisponibles++;
            //    }
            //}

            ////cantidad de habitaciones ocupadas por sede
            //IEnumerable<int> totalPorSede = (from p in result
            //                                 where p.LocationModel.Id == ciudad
            ////                                 select p.LocationModel.TotalHabitaciones);

            //totalHabitacionesDisponibles = totalPorSede.Count() - totalOcupadas;

            //return totalHabitacionesDisponibles;
            return 0;
        }

        public DateTime ValidarFechasDisponibles(DateTime? fecha)
        {
            Task<IEnumerable<Reservation>> reservaciones = reservacionRepository.GetAllReservations();
            IEnumerable<ReservationsModel> result = mapper.Map<IEnumerable<Domain.Models.ReservationsModel>>(reservaciones);

            string message = Constants.superaCapacidadMax + $"{ fecha }";

            foreach (ReservationsModel item in result)
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
