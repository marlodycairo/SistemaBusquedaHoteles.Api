using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;

namespace SistemaBusquedaHoteles.Api.Domain.Mappers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Habitaciones, HabitacionesViewModel>()
                .ForMember(dest => dest.Sedes, opt => opt.MapFrom(src => src.Sede))
                .ForMember(dest => dest.TipoAlojamientos, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.Tarifa, opt => opt.MapFrom(src => src.Tarifa))
                .ForMember(dest => dest.ReservaModel, opt => opt.MapFrom(src => src.Reserva))
                .ForPath(dest => dest.ReservaModel.ClienteModel, member => member.MapFrom(src => src.Reserva.Cliente));

            CreateMap<HabitacionesViewModel, Habitaciones>();

            CreateMap<Sedes, SedesViewModel>();
            CreateMap<SedesViewModel, Sedes>();

            CreateMap<TipoAlojamiento, TipoAlojamientoViewModel>();
            CreateMap<TipoAlojamientoViewModel, TipoAlojamiento>();

            CreateMap<Tarifas, TarifasViewModel>();
            CreateMap<TarifasViewModel, Tarifas>();

            CreateMap<Reservacion, ReservacionViewModel>()
                .ForMember(dest => dest.SedesModel, opt => opt.MapFrom(src => src.Sede))
                .ForMember(dest => dest.TarifasModel, opt => opt.MapFrom(src => src.Tarifa))
                .ForMember(dest => dest.TipoAlojamientoModel, opt => opt.MapFrom(src => src.TAlojamiento))
                .ForMember(dest => dest.ClienteModel, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.HabitacionesModel, opt => opt.MapFrom(src => src.Habitacion));

            CreateMap<ReservacionViewModel, Reservacion>();

            CreateMap<Clientes, ClienteViewModel>();
            CreateMap<ClienteViewModel, Clientes>();
        }
    }
}
