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
    public class RoomTypesRepository : IRoomTypesRepository
    {
        private readonly ApplicationDbContext context;

        public RoomTypesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<RoomTypes> GetAlojamientoById(int id)
        {
            return await context.RoomTypes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<RoomTypes>> GetAlojamientos()
        {
            return await context.RoomTypes.ToListAsync();
        }
    }
}
