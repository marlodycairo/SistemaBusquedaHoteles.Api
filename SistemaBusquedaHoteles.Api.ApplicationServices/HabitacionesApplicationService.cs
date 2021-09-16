using AutoMapper;
using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.ApplicationServices
{
    public class HabitacionesApplicationService : IHabitacionesApplication
    {
        private readonly IHabitacionesDomain habitacionesDomain;
        private readonly IMapper mapper;

        public HabitacionesApplicationService(IHabitacionesDomain habitacionesDomain, IMapper mapper)
        {
            this.habitacionesDomain = habitacionesDomain;
            this.mapper = mapper;
        }

        public HabitacionesViewModel Create(HabitacionesViewModel habitaciones)
        {
            var obHabitaction = mapper.Map<Habitaciones>(habitaciones);

            var result = habitacionesDomain.Create(obHabitaction);

            return result;
        }

        public void Delete(int id)
        {
            habitacionesDomain.Delete(id);
        }

        public IEnumerable<HabitacionesViewModel> GetAll()
        {
            return habitacionesDomain.GetAll();
        }

        public HabitacionesViewModel GetById(int id)
        {
            return habitacionesDomain.GetById(id);
        }

        public HabitacionesViewModel Update(HabitacionesViewModel model)
        {
            return habitacionesDomain.Update(model);
        }
    }
}
