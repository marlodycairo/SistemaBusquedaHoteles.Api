using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;

namespace SistemaBusquedaHoteles.Api.Domain.Mappers
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Rooms, RoomModel>();
            CreateMap<RoomModel, Rooms>();

            CreateMap<Location, LocationsModel>();

            CreateMap<LocationsModel, Location>();

            CreateMap<RoomTypes, RoomTypeModel>();

            CreateMap<RoomTypeModel, RoomTypes>();

            CreateMap<Rate, RatesModel>();

            CreateMap<RatesModel, Rate>();

            CreateMap<Reservation, ReservationsModel>()
                .ForMember(dest => dest.CustomerModel, opt => opt.MapFrom(src => src.Customers));

            CreateMap<ReservationsModel, Reservation>();

            CreateMap<Customer, CustomersModel>();
            CreateMap<CustomersModel, Customer>();
        }
    }
}
