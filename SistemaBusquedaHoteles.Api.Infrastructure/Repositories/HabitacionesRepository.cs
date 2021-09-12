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

        public Habitaciones Create(Habitaciones habitaciones)
        {
            context.Habitaciones.Add(habitaciones);
            context.SaveChanges();

            return habitaciones;
        }

        public void Delete(int id)
        {
            Habitaciones habitacion = context.Habitaciones.FirstOrDefault(p => p.Id == id);

            context.Remove(habitacion).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Habitaciones> GetAll()
        {
            //return context.Habitaciones.ToList();
            return (from p in context.Habitaciones
                        select p).Include(s => s.Sede)
                        .Include(ti => ti.Tipo)
                        .Include(t => t.Tarifa)
                        .Include(r => r.Reserva)
                        .Include(r => r.Reserva)
                        .ThenInclude(c => c.Cliente)
                        .ToList();
        }

        public Habitaciones GetById(int id)
        {
            return context.Habitaciones.FirstOrDefault(p => p.Id == id);
        }

        public Habitaciones Update(Habitaciones habitaciones)
        {
            context.Entry(habitaciones).State = EntityState.Modified;
            context.SaveChanges();

            return habitaciones;
        }
    }
}
