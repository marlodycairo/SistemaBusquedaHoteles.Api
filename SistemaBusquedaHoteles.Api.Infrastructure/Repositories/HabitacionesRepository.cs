using Microsoft.EntityFrameworkCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories
{
    public class HabitacionesRepository : IHabitacionesRepository
    {
        private readonly ApplicationDbContext context;

        public HabitacionesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Rooms Create(Rooms habitaciones)
        {
            context.Habitaciones.Add(habitaciones);
            context.SaveChanges();

            return habitaciones;
        }

        public void Delete(int id)
        {
            Rooms habitacion = context.Habitaciones.FirstOrDefault(p => p.Id == id);

            context.Remove(habitacion).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Rooms> GetAll()
        {
            return context.Habitaciones
                        .Include(t => t.Tipo)
                        .Include(p => p.Sede)
                        .Include(r => r.Reservacion)
                        .ToList();
        }

        public Rooms GetById(int id)
        {
            return context.Habitaciones.FirstOrDefault(p => p.Id == id);
        }

        public Rooms Update(Rooms habitaciones)
        {
            context.Entry(habitaciones).State = EntityState.Modified;
            context.SaveChanges();

            return habitaciones;
        }
    }
}
