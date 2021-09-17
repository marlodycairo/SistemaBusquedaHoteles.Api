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
            //listado de reservaciones
            var reservas = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservas);

            //listado de habitaciones
            var habitaciones = habitacionesRepository.GetAll();
            var listaHabitaciones = mapper.Map<IEnumerable<HabitacionesViewModel>>(habitaciones);

            var listHabitaciones = habitacionesRepository.GetAll();
            var lista = mapper.Map<IEnumerable<HabitacionesViewModel>>(habitaciones);

            var sedes = sedesRepository.GetSedes();
            var lstSedes = mapper.Map<IEnumerable<SedesViewModel>>(sedes);

            ReservacionViewModel reservacion = new ReservacionViewModel();

            var reservaciones = new List<ReservacionViewModel>();

            var habitacion = new List<HabitacionesViewModel>();

            var realizarReserva = new List<ReservacionViewModel>();

            if (filter.Ciudad != null)
            {
                result = result.Where(p => p.SedesModel.Ciudad.ToLower() == filter.Ciudad.ToLower());
            }

            if (filter.Fecha != null)
            {
                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository,
                    tarifasRepository, alojamientoRepository, sedesRepository);

                string message = $"Lo sentimos, no hay habitaciones disponibles para la fecha seleccionada { filter.Fecha }.";

                foreach (var item in result)
                {
                    if (filter.Fecha == item.Fecha || filter.Fecha < item.Fecha)
                    {
                        //Envia un mensaje si la fecha no está disponible.
                        testList.Add(new ReservacionViewModel()
                        {
                            Fecha = item.Fecha,
                            Respuesta = message
                        });
                        return testList;
                    }
                }
                //si la fecha esta disponible debe permitirle ver las habitaciones disponibles de la sede seleccionada
                var disponibilidad = reserva.CalcularHabitacionesDisponibles(filter.Ciudad);
            }

            if (filter.TotalPersonas != 0)
            {
                string message = $"No hay habitaciones disponibles en la fecha { filter.Fecha } para alojar la cantidad de huespedes seleccionados. Recuerde que tiene la opción de reservar varias habitaciones.";
                foreach (var item in result)
                {
                    if (filter.TotalPersonas > item.SedesModel.CupoMax)
                    {
                        //Envia un mensaje si supera la cantidad de huespedes por habitación
                        testList.Add(new ReservacionViewModel()
                        {
                            Respuesta = message
                        });
                        return testList;
                    }
                }
            }

            if (filter.TotalHabitaciones != 0)
            {
                var reservaciones = new ReservacionViewModel();

                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository, tarifasRepository, alojamientoRepository, sedesRepository);

                var test = reserva.CalcularHabitacionesDisponibles(filter.Ciudad.ToLower());

                result = result.Where(p => p.TotalHabitaciones == filter.TotalHabitaciones);
            }

            if (filter.SeleccionarTipoHabitacion != null)
            {
                //Consultar tarifas segun tipo de habitacion elegido
                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository,
                    tarifasRepository, alojamientoRepository, sedesRepository);

                var query = from p in lista
                            join r in result
                            on p.TipoAlojamientos.Nombre equals r.TipoAlojamientoModel.Nombre
                            where p.TipoAlojamientos.Nombre.ToLower() == filter.SeleccionarTipoHabitacion.ToLower()
                            where r.SedesModel.Ciudad.ToLower() == filter.Ciudad.ToLower()
                            where p.Estado == "disponible"
                            select r;

                foreach (var item in query)
                {
                    testList.Add(new ReservacionViewModel()
                    {
                        Fecha = item.Fecha,
                        Sede = item.SedesModel.Ciudad,
                        TipoDeAlojamiento = item.TipoAlojamientoModel.Nombre,
                        Estado = item.Estado
                    });
                }
                var pruebas = reserva.TarifasDisponibles(filter.Fecha, filter.SeleccionarTipoHabitacion);

                double totalAPagar = filter.TotalHabitaciones * pruebas;
            }
            return testList;
        }

        public ReservacionViewModel UpdateReservacion(ReservacionViewModel reservacion)
        {
            var reservas = mapper.Map<Reservacion>(reservacion);

            reservacionRepository.UpdateReservacion(reservas);

            return reservacion;
        }

        public double TarifasDisponibles(DateTime? fecha, string tipoHabitacion)
        {
            double valorHabitacion = 0;

            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            //listado de habitaciones
            var habitaciones = habitacionesRepository.GetAll();
            var lista = mapper.Map<IEnumerable<HabitacionesViewModel>>(habitaciones);

            var tarifas = tarifasRepository.GetTarifas();
            var listaTarifas = mapper.Map<IEnumerable<TarifasViewModel>>(tarifas);

            var tipos = alojamientoRepository.GetAlojamientos();
            var alojamientos = mapper.Map<IEnumerable<TipoAlojamientoViewModel>>(tipos);

            var sedes = sedesRepository.GetSedes();
            var lstSedes = mapper.Map<IEnumerable<SedesViewModel>>(sedes);

            var listadotarifas = new List<TarifasViewModel>();

            var objTarifas = new TarifasViewModel();

            var objHabitaciones = new HabitacionesViewModel();

            var listadoReservas = new List<ReservacionViewModel>();

            //Fecha inicio temporada baja meses Septiembre 1 hasta Octubre 30
            var fInicioBaj2 = new DateTime(2021, 9, 1);

            //Temporada Baja meses Septiembre - Octubre
            DateTime tBaja2 = new DateTime(2021, 9, 1).AddMonths(1).AddDays(31);

            //Fecha inicio temporada baja meses Abril 22 hasta 20 de junio
            var fInicioBaj1 = new DateTime(2022, 4, 21);

            //Temporada Baja Abril + Mayo + hasta el 22 de junio +Septiembre a octubre
            DateTime tBaja1 = new DateTime(2022, 4, 22).AddMonths(2);

            var test = (from p in lista
                        join reservas in result on p.TipoAlojamientos.Nombre equals reservas.TipoAlojamientoModel.Nombre
                        where p.TipoAlojamientos.Nombre == tipoHabitacion
                        select reservas);

            foreach (var item in test)
            {
                if (fecha >= fInicioBaj2 && fecha <= tBaja2 || fecha >= fInicioBaj1 && fecha <= tBaja1)
                {
                    valorHabitacion = item.TarifasModel.Valor;
                }
                else
                {
                    item.TarifasModel.Temporada = "alta";
                }
            }

            return valorHabitacion;
        }

        public DateTime CalcularTemporada(DateTime? fechaConsulta)
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            //Fecha inicio temporada alta meses Noviembre 1 hasta Abril 20
            var fInicioAl1 = new DateTime(2021, 11, 1);

            //Temporada Alta es desde el 20 de junio, Julio y agosto.
            DateTime tAlta1 = new DateTime(2021, 11, 1).AddMonths(5).AddDays(20);

            //Fecha inicio temporada alta meses Junio 21 hasta Agosto 30
            var fInicioAl2 = new DateTime(2022, 6, 21);

            //desde el 21 de junio, Julio hasta agosto 30.
            DateTime tAlta2 = new DateTime(2022, 6, 21).AddMonths(2).AddDays(11);

            //Obtiene las fechas para el tiempo asignada.
            var fechaInit = new DateTime(2021, 1, 1);
            var fFin = new DateTime(2022, 12, 31).AddDays(1);

            var listadoFechas = new List<DateTime>();

            for (DateTime fechas = fechaInit; fechas < fFin; fechas = fechas.AddDays(1))
            {
                listadoFechas.Add(fechas);
            }

            //temporada baja
            //Fecha inicio temporada baja meses Abril 22 hasta 20 de junio
            var fInicioBaj1 = new DateTime(2022, 4, 21);

            //Temporada Baja Abril + Mayo + hasta el 22 de junio +Septiembre a octubre
            DateTime tBaja1 = new DateTime(2022, 4, 22).AddMonths(2);

            //Fecha inicio temporada baja meses Septiembre 1 hasta Octubre 30
            var fInicioBaj2 = new DateTime(2021, 9, 1);

            //Temporada Baja meses Septiembre - Octubre
            DateTime tBaja2 = new DateTime(2021, 9, 1).AddMonths(1).AddDays(31);

            var temporadaAlta = new List<DateTime>();
            var TAlta = new List<DateTime>();
            var TBaja = new List<DateTime>();
            foreach (var item in listadoFechas)
            {
                for (DateTime fecha = fInicioAl1; fecha < tAlta1; fecha = fecha.AddDays(1))
                {
                    if (item == fecha)
                    {
                        TAlta.Add(item);
                    }
                }

                for (DateTime fecha = fInicioAl2; fecha < tAlta2; fecha = fecha.AddDays(1))
                {
                    if (item == fecha)
                    {
                        TAlta.Add(item);
                    }
                }

                for (DateTime fecha = fInicioBaj2; fecha < tBaja2; fecha = fecha.AddDays(1))
                {
                    if (item == fecha)
                    {
                        TBaja.Add(item);
                    }
                }

                for (DateTime fecha = fInicioBaj1; fecha < tBaja1; fecha = fecha.AddDays(1))
                {
                    if (item == fecha)
                    {
                        TBaja.Add(item);
                    }
                }
            }

            foreach (var item in TBaja)
            {
                if (fechaConsulta == item)
                {
                    //var alta = "Temporada Alta";
                    //var baja = "Temporada Baja";
                    string message = "Temporada Baja";
                    return item;
                }
            }
            return DateTime.Now;
        }

        //Realizado
        public int CalcularHabitacionesDisponibles(string ciudad)
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            var habitaciones = habitacionesRepository.GetAll();
            var listaHabitaciones = mapper.Map<IEnumerable<HabitacionesViewModel>>(habitaciones);

            var sedes = sedesRepository.GetSedes();
            var listadoSedes = mapper.Map<IEnumerable<SedesViewModel>>(sedes);

            int totalHabitacionesDisponibles = 0;
            int totalOcupadas = 0;
            int totalDisponibles = 0;
            //int total = 0;

            List<ReservacionViewModel> model = new List<ReservacionViewModel>();
            List<SedesViewModel> sedesViews = new List<SedesViewModel>();

            foreach (var item in result)
            {
                if (item.SedesModel.Ciudad.ToLower() == ciudad.ToLower())
                {
                    totalOcupadas++;
                }
            }

            var tipos = from p in listaHabitaciones
                        join s in result
                        on p.TipoAlojamientos.Nombre equals s.TipoAlojamientoModel.Nombre
                        select s;

            foreach (var item in tipos)
            {
                if (item.SedesModel.Ciudad.ToLower() == ciudad.ToLower() && item.HabitacionesModel.Estado == "disponible")
                {
                    totalDisponibles++;
                }
            }

            //cantidad de habitaciones ocupadas por sede
            var totalPorSede = (from p in result
                                where p.SedesModel.Ciudad.ToLower() == ciudad.ToLower()
                                select p.SedesModel.TotalHabitaciones).FirstOrDefault();

            //restar cantidad de habitaciones segun los tipos de alojamiento//estandar, premium o vip

            totalHabitacionesDisponibles = totalPorSede - totalOcupadas;


            return totalHabitacionesDisponibles;
        }


        public DateTime ValidarFechasDisponibles(DateTime? fecha)
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            var message = $"No hay habitaciones disponibles para el { fecha }. Seleccione otra fecha.";

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
