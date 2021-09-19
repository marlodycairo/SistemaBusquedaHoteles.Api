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
    public class SedesRepository : ISedesRepository
    {
        private readonly ApplicationDbContext context;

        public SedesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Locations> GetSedeById(int id)
        {
            return await context.Locations.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Locations>> GetSedes()
        {
            return await context.Locations
                .Include(p => p.Rooms)
                .Include(r => r.Reservations)
                .ToListAsync();
        }
    }
}
