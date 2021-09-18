using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;

namespace SistemaBusquedaHoteles.Api.Domain.Mappers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Rooms, HabitacionesViewModel>()
                .ForMember(dest => dest.TipoAlojamientos, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.SedesView, opt => opt.MapFrom(src => src.Sede));

            CreateMap<HabitacionesViewModel, Rooms>();

            CreateMap<Locations, SedesViewModel>();

            CreateMap<SedesViewModel, Locations>();

            CreateMap<RoomType, TipoAlojamientoViewModel>();
            CreateMap<TipoAlojamientoViewModel, RoomType>();

            CreateMap<Rates, TarifasViewModel>()
                .ForMember(dest => dest.AlojamientoModel, opt => opt.MapFrom(src => src.Alojamiento));

            CreateMap<TarifasViewModel, Rates>();

            CreateMap<Reservation, ReservacionViewModel>()
                .ForMember(dest => dest.SedesModel, opt => opt.MapFrom(src => src.Sede))
                .ForMember(dest => dest.TarifasModel, opt => opt.MapFrom(src => src.Tarifa))
                .ForMember(dest => dest.TipoAlojamientoModel, opt => opt.MapFrom(src => src.TAlojamiento))
                .ForMember(dest => dest.ClienteModel, opt => opt.MapFrom(src => src.Cliente))
                .ForMember(dest => dest.HabitacionesModel, opt => opt.MapFrom(src => src.Habitacion));

            CreateMap<ReservacionViewModel, Reservation>();

            CreateMap<Customer, ClienteViewModel>();
            CreateMap<ClienteViewModel, Customer>();
        }
    }
}
