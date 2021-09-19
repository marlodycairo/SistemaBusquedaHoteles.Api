using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class TipoAlojamientoDomainServices : ITipoAlojamientoDomain
    {
        private readonly ITipoAlojamientoRepository tipoAlojamientoRepository;
        private readonly IMapper mapper;

        public TipoAlojamientoDomainServices(ITipoAlojamientoRepository tipoAlojamientoRepository, IMapper mapper)
        {
            this.tipoAlojamientoRepository = tipoAlojamientoRepository;
            this.mapper = mapper;
        }

        public async Task<RoomTypeModel> GetAlojamientoById(int id)
        {
            var roomTypeById = await tipoAlojamientoRepository.GetAlojamientoById(id);

            var roomType = mapper.Map<RoomTypeModel>(roomTypeById);

            return roomType;
        }

        public async Task<IEnumerable<RoomTypeModel>> GetAlojamientos()
        {
            var allRoomTypes = await tipoAlojamientoRepository.GetAlojamientos();

            var roomTypes = mapper.Map<IEnumerable<RoomTypeModel>>(allRoomTypes);

            return roomTypes;
        }
    }
}
