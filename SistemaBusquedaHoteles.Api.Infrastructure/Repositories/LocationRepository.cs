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
    public class LocationRepository : ILocationRepository
    {
        private readonly ApplicationDbContext context;

        public LocationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Location> GetSedeById(int id)
        {
            return await context.Location.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Location>> GetSedes()
        {
            return await context.Location
                .ToListAsync();
        }
    }
}
