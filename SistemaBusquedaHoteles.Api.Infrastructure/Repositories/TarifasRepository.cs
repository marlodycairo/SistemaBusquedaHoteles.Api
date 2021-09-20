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

        public Task<Rate> GetTarifaById(int id)
        {
            var rate = context.Rate.FirstOrDefaultAsync(p => p.Id == id);

            return rate;
        }

        public async Task<IEnumerable<Rate>> GetTarifas()
        {
            return await context.Rate
                .Include(r => r.Reservations)
                .ToListAsync();
        }
    }
}
