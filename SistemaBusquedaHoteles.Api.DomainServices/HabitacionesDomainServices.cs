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

        public HabitacionesViewModel Create(Habitaciones habitaciones)
        {
            habitacionesRepository.Create(habitaciones);

            var result = mapper.Map<HabitacionesViewModel>(habitaciones);

            return result;
        }

        public void Delete(int id)
        {
            habitacionesRepository.Delete(id);
        }

        public IEnumerable<HabitacionesViewModel> GetAll()
        {
            var habitaciones = habitacionesRepository.GetAll();

            var result = mapper.Map<IEnumerable<HabitacionesViewModel>>(habitaciones);

            return result;
        }

        public HabitacionesViewModel GetById(int id)
        {
            var habitacion = habitacionesRepository.GetById(id);

            var result = mapper.Map<HabitacionesViewModel>(habitacion);

            return result;
        }

        public HabitacionesViewModel Update(HabitacionesViewModel model)
        {
            var consulta = mapper.Map<Habitaciones>(model);

            habitacionesRepository.Update(consulta);

            return model;
        }
    }
}
