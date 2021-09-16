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

        public ReservacionDomainServices(IReservacionRepository reservacionRepository, IMapper mapper, IHabitacionesRepository habitacionesRepository)
        {
            this.reservacionRepository = reservacionRepository;
            this.mapper = mapper;
            this.habitacionesRepository = habitacionesRepository;
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

            var habitaciones = habitacionesRepository.GetAll();
            var listaHabitaciones = mapper.Map<IEnumerable<HabitacionesViewModel>>(habitaciones);

            ReservacionViewModel testModel = new ReservacionViewModel();

            var testList = new List<ReservacionViewModel>();

            var realizarReserva = new List<ReservacionViewModel>();

            //Realizado
            if (filter.Ciudad != null)
            {
                result = result.Where(p => p.SedesModel.Ciudad.ToLower() == filter.Ciudad.ToLower());
            }

            //Realizado
            if (filter.Fecha != null)
            {
                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository);

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


                //result = result.Where(p => p.Fecha.ToShortDateString() == filter.Fecha?.ToShortDateString());
            }

            //Realizado
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
                //result = result.Where(p => p.SedesModel.CupoMax <= filter.TotalPersonas);
            }



            if (filter.TotalHabitaciones != 0)
            {
                var reservaciones = new ReservacionViewModel();

                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository);

                var test = reserva.CalcularHabitacionesDisponibles(filter.Ciudad.ToLower());



                result = result.Where(p => p.TotalHabitaciones == filter.TotalHabitaciones);
            }



            if (filter.SeleccionarTipoHabitacion != null)
            {
                //Ver tarifas segun tipo de habitacion elegido
                var reserva = new ReservacionDomainServices(reservacionRepository, mapper, habitacionesRepository);
                var habitacion = new List<HabitacionesViewModel>();

                var listHabitaciones = habitacionesRepository.GetAll();
                var lista = mapper.Map<IEnumerable<HabitacionesViewModel>>(habitaciones);

                var tipoHabitacion = (from p in lista
                                     where p.TipoAlojamientos.Nombre.ToLower() == filter.SeleccionarTipoHabitacion.ToLower() && p.Sedes.Ciudad.ToLower() == filter.Ciudad.ToLower() && p.Estado == "disponible"
                                     select p).ToList();

                foreach (var item in tipoHabitacion)
                {
                    habitacion.Add(new HabitacionesViewModel() 
                    {
                        Sedes = item.Sedes,
                        TipoAlojamientos = item.TipoAlojamientos,
                        Estado = item.Estado
                    });
                }
                var listado = habitacion.ToList();


                var test = reserva.TarifasDisponibles();
            }

            return result;
        }

        public ReservacionViewModel UpdateReservacion(ReservacionViewModel reservacion)
        {
            var reservas = mapper.Map<Reservacion>(reservacion);

            reservacionRepository.UpdateReservacion(reservas);

            return reservacion;
        }


        public double TarifasDisponibles()
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            var test = from p in result
                       select p;



            return 0;
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

            //var alta = "Temporada Alta";
            //var baja = "Temporada Baja";
            var message = "";

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
                    message = "Temporada Baja";
                    return item;
                }
            }

            //if (fechaConsulta >= fInicioBaj2 && fechaConsulta <= tBaja2 || fInicioBaj1 >= fechaConsulta && fechaConsulta <= tBaja1)
            //{
            //    return fechaConsulta.Value;
            //}


            return DateTime.Now;
        }

        
        public double CalcularValorAPagar()
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            return 0;
        }

        //Realizado
        public int CalcularHabitacionesDisponibles(string ciudad)
        {
            var reservaciones = reservacionRepository.GetReservaciones();
            var result = mapper.Map<IEnumerable<ReservacionViewModel>>(reservaciones);

            var habitaciones = habitacionesRepository.GetAll();
            var listaHabitaciones = mapper.Map<IEnumerable<HabitacionesViewModel>>(habitaciones);

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
                         select p;

            foreach (var item in listaHabitaciones)
            {
                if (item.Sedes.Ciudad.ToLower() == ciudad.ToLower() && item.Estado == "disponible")
                {
                    totalDisponibles++;
                }
            }

            //cantidad de habitaciones ocupadas por sede
            var totalPorSede = (from p in result
                                where p.HabitacionesModel.Sedes.Ciudad.ToLower() == ciudad.ToLower()
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
