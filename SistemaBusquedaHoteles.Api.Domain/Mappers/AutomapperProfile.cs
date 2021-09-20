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
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType))
                .ForMember(dest => dest.Locations, opt => opt.MapFrom(src => src.Locations));

            CreateMap<RoomModel, Rooms>();

            CreateMap<Location, LocationsModel>();

            CreateMap<LocationsModel, Location>();

            CreateMap<RoomTypes, RoomTypeModel>();
            CreateMap<RoomTypeModel, RoomTypes>();

            CreateMap<Rate, RatesModel>();
                //.ForMember(dest => dest.RoomTypesModel, opt => opt.MapFrom(src => src.RoomType));

            CreateMap<RatesModel, Rate>();

            CreateMap<Reservation, ReservationsModel>()
                .ForMember(dest => dest.LocationModel, opt => opt.MapFrom(src => src.Locations))
                .ForMember(dest => dest.RateModel, opt => opt.MapFrom(src => src.Rates))
                .ForMember(dest => dest.RoomTypesModel, opt => opt.MapFrom(src => src.RoomType))
                .ForMember(dest => dest.CustomerModel, opt => opt.MapFrom(src => src.Customers))
                .ForMember(dest => dest.RoomsModel, opt => opt.MapFrom(src => src.Room));

            CreateMap<ReservationsModel, Reservation>();

            CreateMap<Customer, CustomersModel>();
            CreateMap<CustomersModel, Customer>();

            CreateMap<ReservationsRooms, ReservationRoomModel>()
                .ForMember(dest => dest.ReservationModel, opt => opt.MapFrom(src => src.Reservations))
                .ForMember(dest => dest.RoomsModel, opt => opt.MapFrom(src => src.Room))
                .ForPath(dest => dest.ReservationModel.RoomsModel, member => member.MapFrom(src => src.Reservations.Room))
                .ForPath(dest => dest.RoomsModel.Reservations, member => member.MapFrom(src => src.Room.Reservations));

            CreateMap<ReservationRoomModel, ReservationsRooms>();
        }
    }
}
