using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;

namespace SistemaBusquedaHoteles.Api.Domain.Mappers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Rooms, Room>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomTypes))
                .ForMember(dest => dest.Locations, opt => opt.MapFrom(src => src.Location));

            CreateMap<Room, Rooms>();

            CreateMap<Location, Locations>();

            CreateMap<Locations, Location>();

            CreateMap<RoomTypes, RoomType>();
            CreateMap<RoomType, RoomTypes>();

            CreateMap<Rate, Rates>()
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomTypes));

            CreateMap<Rates, Rate>();

            CreateMap<Reservation, Reservations>()
                .ForMember(dest => dest.Locations, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Rates, opt => opt.MapFrom(src => src.Rate))
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomTypes))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Rooms));

            CreateMap<Reservations, Reservation>();

            CreateMap<Customer, Customers>();
            CreateMap<Customers, Customer>();
        }
    }
}
