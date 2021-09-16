using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;

namespace SistemaBusquedaHoteles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscadorController : ControllerBase
    {
        private readonly IBuscadorApplication buscadorApplication;
        private readonly IHabitacionesApplication habitacionesApplication;

        public BuscadorController(IBuscadorApplication buscadorApplication, IHabitacionesApplication habitacionesApplication)
        {
            this.buscadorApplication = buscadorApplication;
            this.habitacionesApplication = habitacionesApplication;
        }

        [HttpGet]
        public ActionResult<GenericPagination<HabitacionesViewModel>> ConsultarAlojamiento(string buscar, DateTime fecha, string orden = "Id", string tipo_Orden = "ASC", int pagina = 1, int registro_por_pagina = 10)
        {
            List<HabitacionesViewModel> obHabitaciones; //= new List<HabitacionesViewModel>();

            GenericPagination<HabitacionesViewModel> paginadorModel;

            obHabitaciones = (List<HabitacionesViewModel>)habitacionesApplication.GetAll();

            List<ReservacionViewModel> result = new List<ReservacionViewModel>();


            var query = from p in obHabitaciones
                        select p.Fecha;

            //Ciudades
            if (!string.IsNullOrEmpty(buscar))
            {
                foreach (string item in buscar.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    obHabitaciones = obHabitaciones.Where(p => p.Sedes.Ciudad.ToLower().Contains(item.ToLower().Trim())
                                                            || p.TipoAlojamientos.Nombre.ToLower().Contains(item.ToLower().Trim())).ToList();
                                                            //|| Convert.ToString(p.Tarifa.Valor).Contains(item.Trim())).ToList();
                }
            }

            switch (orden)
            {
                case "Id":
                    if (tipo_Orden.ToLower() == "desc")
                    {
                        obHabitaciones = obHabitaciones.OrderByDescending(p => p.Sedes.Ciudad).ToList();
                    }
                    else if (tipo_Orden.ToLower() == "asc")
                    {
                        obHabitaciones = obHabitaciones.OrderBy(p => p.Sedes.Ciudad).ToList();
                    }

                    break;

                case "TipoAlojamientos.Nombre":
                    if (tipo_Orden.ToLower() == "desc")
                    {
                        obHabitaciones = obHabitaciones.OrderByDescending(p => p.TipoAlojamientos.Nombre).ToList();
                    }
                    else if (tipo_Orden.ToLower() == "asc")
                    {
                        obHabitaciones = obHabitaciones.OrderBy(p => p.TipoAlojamientos.Nombre).ToList();
                    }

                    break;

                //case "Tarifa.Valor":
                //    if (tipo_Orden.ToLower() == "desc")
                //    {
                //        obHabitaciones = obHabitaciones.OrderByDescending(p => p.Tarifa.Valor).ToList();
                //    }
                //    else if (tipo_Orden.ToLower() == "asc")
                //    {
                //        obHabitaciones = obHabitaciones.OrderBy(p => p.Tarifa.Valor).ToList();
                //    }

                   // break;
                default:
                    if (tipo_Orden.ToLower() == "desc")
                    {
                        obHabitaciones = obHabitaciones.OrderByDescending(p => p.Sedes.Ciudad).ToList();
                    }
                    else if (tipo_Orden.ToLower() == "asc")
                    {
                        obHabitaciones = obHabitaciones.OrderBy(p => p.Sedes.Ciudad).ToList();
                    }

                    break;
            }

            int totalRegistros = 0;
            int totalPaginas = 0;

            totalRegistros = obHabitaciones.Count();

            obHabitaciones = obHabitaciones.Skip((pagina - 1) * registro_por_pagina).Take(registro_por_pagina).ToList();

            totalPaginas = (int)Math.Ceiling((double)totalRegistros / registro_por_pagina);

            paginadorModel = new GenericPagination<HabitacionesViewModel>()
            {
                RegistroPorPagina = registro_por_pagina,
                TotalRegistros = totalRegistros,
                TotalPaginas = totalPaginas,
                PaginaActual = pagina,
                //BusquedaActual = buscar,
                OrdenActual = orden,
                TipoOrdenActual = tipo_Orden,
                Resultado = obHabitaciones
            };

            return paginadorModel;
        }
    }
}
