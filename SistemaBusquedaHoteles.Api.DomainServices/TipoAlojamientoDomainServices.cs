﻿using AutoMapper;
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

        public RoomType GetAlojamientoById(int id)
        {
            var tAlojamiento = tipoAlojamientoRepository.GetAlojamientoById(id);

            var result = mapper.Map<RoomType>(tAlojamiento);

            return result;
        }

        public IEnumerable<RoomType> GetAlojamientos()
        {
            var tipos = tipoAlojamientoRepository.GetAlojamientos();

            var result = mapper.Map<IEnumerable<RoomType>>(tipos);

            return result;
        }
    }
}
