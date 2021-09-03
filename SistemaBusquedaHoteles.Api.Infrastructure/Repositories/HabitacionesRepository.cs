using Microsoft.EntityFrameworkCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories
{
    public class HabitacionesRepository : IHabitacionesRepository
    {
        private readonly ApplicationDbContext context;

        public HabitacionesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Habitaciones Create(Habitaciones habitaciones)
        {
            context.Habitaciones.Add(habitaciones);
            context.SaveChanges();

            return habitaciones;
        }

        public void Delete(int id)
        {
            var habitacion = context.Habitaciones.FirstOrDefault(p => p.Id == id);

            context.Remove(habitacion);
            context.SaveChanges();
        }

        public IEnumerable<Habitaciones> GetAll()
        {
            return context.Habitaciones.ToList();
        }

        public Habitaciones GetById(int id)
        {
            return context.Habitaciones.Find(id);
        }

        public Habitaciones Update(Habitaciones habitaciones)
        {
            context.Entry(habitaciones).State = EntityState.Modified;
            context.SaveChanges();

            return habitaciones;
        }
    }
}
