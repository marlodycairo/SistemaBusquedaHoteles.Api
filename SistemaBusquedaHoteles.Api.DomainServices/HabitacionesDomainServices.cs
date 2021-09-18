using AutoMapper;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Helpers;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBusquedaHoteles.Api.DomainServices
{
    public class HabitacionesDomainServices : IHabitacionesDomain
    {
        private readonly IHabitacionesRepository habitacionesRepository;
        private readonly IMapper mapper;

        public HabitacionesDomainServices(IHabitacionesRepository habitacionesRepository, IMapper mapper)
        {
            this.habitacionesRepository = habitacionesRepository;
            this.mapper = mapper;
        }

        public Domain.Models.Rooms Create(Infrastructure.Entities.Rooms habitaciones)
        {
            habitacionesRepository.Create(habitaciones);

            var result = mapper.Map<Domain.Models.Rooms>(habitaciones);

            return result;
        }

        public void Delete(int id)
        {
            habitacionesRepository.Delete(id);
        }

        public IEnumerable<Domain.Models.Rooms> GetAll()
        {
            var habitaciones = habitacionesRepository.GetAll();

            var result = mapper.Map<IEnumerable<Domain.Models.Rooms>>(habitaciones);

            return result;
        }

        public Domain.Models.Rooms GetById(int id)
        {
            var habitacion = habitacionesRepository.GetById(id);

            var result = mapper.Map<Domain.Models.Rooms>(habitacion);

            return result;
        }

        public Domain.Models.Rooms Update(Domain.Models.Rooms model)
        {
            var consulta = mapper.Map<Infrastructure.Entities.Rooms>(model);

            habitacionesRepository.Update(consulta);

            return model;
        }
    }
}
