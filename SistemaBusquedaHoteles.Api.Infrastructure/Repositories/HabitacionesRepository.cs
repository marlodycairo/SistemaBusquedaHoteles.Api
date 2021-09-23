using Microsoft.EntityFrameworkCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Rooms> Create(Rooms rooms)
        {
            await context.Rooms.AddAsync(rooms);
            await context.SaveChangesAsync();
            return rooms;
        }

        public async Task Delete(int id)
        {
            var habitacion = context.Rooms.FirstOrDefaultAsync(p => p.Id == id);
            context.Remove(habitacion);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rooms>> GetAll()
        {
            return await context.Rooms
                        .ToListAsync();
        }

        public async Task<Rooms> GetById(int id)
        {
            return await context.Rooms.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Rooms> Update(Rooms room)
        {
            var roomUpdate = await context.Rooms.FirstOrDefaultAsync(p => p.Id == room.Id);
            context.Update(roomUpdate);
            await context.SaveChangesAsync();

            return roomUpdate;
        }
    }
}
