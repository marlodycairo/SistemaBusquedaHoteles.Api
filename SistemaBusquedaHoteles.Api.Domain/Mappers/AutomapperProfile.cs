using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Mappers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Habitaciones, HabitacionesViewModel>();
            CreateMap<HabitacionesViewModel, Habitaciones>();

            CreateMap<Sedes, SedesViewModel>();
            CreateMap<SedesViewModel, Sedes>();

            CreateMap<TipoAlojamiento, TipoAlojamientoViewModel>();
            CreateMap<TipoAlojamientoViewModel, TipoAlojamiento>();
        }
    }
}
