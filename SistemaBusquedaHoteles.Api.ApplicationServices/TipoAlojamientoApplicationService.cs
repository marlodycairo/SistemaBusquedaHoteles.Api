using AutoMapper;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.ApplicationServices
{
    public class TipoAlojamientoApplicationService : IRoomTypesApplication
    {
        private readonly IRoomTypesDomain tipoAlojamientoDomain;
        private readonly IMapper mapper;

        public TipoAlojamientoApplicationService(IRoomTypesDomain tipoAlojamientoDomain, IMapper mapper)
        {
            this.tipoAlojamientoDomain = tipoAlojamientoDomain;
            this.mapper = mapper;
        }

        public async Task<RoomTypeModel> GetAlojamientoById(int id)
        {
            return await tipoAlojamientoDomain.GetAlojamientoById(id);
        }

        public async Task<IEnumerable<RoomTypeModel>> GetAlojamientos()
        {
            return await tipoAlojamientoDomain.GetAlojamientos();
        }
    }
}
