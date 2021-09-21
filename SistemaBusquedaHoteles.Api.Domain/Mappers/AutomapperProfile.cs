using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;

namespace SistemaBusquedaHoteles.Api.Domain.Mappers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Rooms, RoomModel>()
                .ForMember(dest => dest.ReservationsModel, opt => opt.MapFrom(src => src.Reservations));

            CreateMap<RoomModel, Rooms>();

            CreateMap<Location, LocationsModel>()
                .ForMember(dest => dest.ReservationsModels, opt => opt.MapFrom(src => src.Reservations));

            CreateMap<LocationsModel, Location>();

            CreateMap<RoomTypes, RoomTypeModel>()
                .ForMember(dest => dest.RatesModels, opt => opt.MapFrom(src => src.Rates))
                .ForMember(dest => dest.ReservationsModels, opt => opt.MapFrom(src => src.Reservations));

            CreateMap<RoomTypeModel, RoomTypes>();

            CreateMap<Rate, RatesModel>()
                .ForMember(dest => dest.RoomTypesModel, opt => opt.MapFrom(src => src.RoomType));

            CreateMap<RatesModel, Rate>();

            CreateMap<Reservation, ReservationsModel>()
                .ForMember(dest => dest.LocationModel, opt => opt.MapFrom(src => src.Locations))
                .ForMember(dest => dest.RateModel, opt => opt.MapFrom(src => src.Rates))
                .ForMember(dest => dest.RoomTypesModel, opt => opt.MapFrom(src => src.RoomType))
                .ForMember(dest => dest.CustomerModel, opt => opt.MapFrom(src => src.Customers));

            CreateMap<ReservationsModel, Reservation>();

            CreateMap<Customer, CustomersModel>();
            CreateMap<CustomersModel, Customer>();
        }
    }
}
