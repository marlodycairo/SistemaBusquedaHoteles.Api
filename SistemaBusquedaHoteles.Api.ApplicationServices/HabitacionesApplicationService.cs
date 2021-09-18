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

        public Domain.Models.Rooms Create(Domain.Models.Rooms habitaciones)
        {
            var obHabitaction = mapper.Map<Infrastructure.Entities.Rooms>(habitaciones);

            var result = habitacionesDomain.Create(obHabitaction);

            return result;
        }

        public void Delete(int id)
        {
            habitacionesDomain.Delete(id);
        }

        public IEnumerable<Domain.Models.Rooms> GetAll()
        {
            return habitacionesDomain.GetAll();
        }

        public Domain.Models.Rooms GetById(int id)
        {
            return habitacionesDomain.GetById(id);
        }

        public Domain.Models.Rooms Update(Domain.Models.Rooms model)
        {
            return habitacionesDomain.Update(model);
        }
    }
}
