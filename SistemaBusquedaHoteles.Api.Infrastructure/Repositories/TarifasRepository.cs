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
    public class TarifasRepository : ITarifasRepository
    {
        private readonly ApplicationDbContext context;

        public TarifasRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Task<Rates> GetTarifaById(int id)
        {
            var rate = context.Rates.FirstOrDefaultAsync(p => p.Id == id);

            return rate;
        }

        public async Task<IEnumerable<Rates>> GetTarifas()
        {
            return await context.Rates
                .Include(p => p.RoomType)
                .Include(r => r.Reservation)
                .ToListAsync();
        }
    }
}
