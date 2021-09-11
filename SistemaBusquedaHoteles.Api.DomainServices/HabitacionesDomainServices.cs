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

        public IEnumerable<HabitacionesViewModel> GetAll(HabitacionesQueryFilter filter)
        {
            var habitaciones = habitacionesRepository.GetAll();

            var result = mapper.Map<IEnumerable<HabitacionesViewModel>>(habitaciones);

            if (filter.Ciudad != null)
            {
                result = result.Where(p => p.Sedes.Ciudad.ToLower() == filter.Ciudad.ToLower());
            }

            if (filter.Fecha != null)
            {
                foreach (var item in result)
                {
                    if (!Equals(item.Fecha, filter.Fecha))
                    {
                        //item.Estado = true;
                    }
                }

                result = result.Where(p => p.Fecha.ToShortDateString() == filter.Fecha?.ToShortDateString());
            }

            if (filter.Tarifa != 0)
            {
                foreach (var item in result)
                {
                    if (item.TipoAlojamientos.Nombre == filter.Tipo)
                    {
                        var test = item.Tarifa.Valor;
                    }
                }

                result = result.Where(p => p.Tarifa.Valor == filter.Tarifa);
            }

            if (filter.CantidadPersonas != 0)
            {
                result = result.Where(p => p.Sedes.CupoMax == filter.CantidadPersonas);
            }

            if (filter.Tipo != null)
            {
                foreach (var item in result)
                {
                    var test = item.TipoAlojamientos.Nombre;
                    item.TipoAlojamientos.Nombre = test;
                }

                result = result.Where(p => p.TipoAlojamientos.Nombre.ToLower() == filter.Tipo.ToLower());
            }

            if (filter.TotalHabitaciones != 0)
            {
                result = result.Where(p => p.Sedes.TotalHabitaciones == filter.TotalHabitaciones);
            }

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
