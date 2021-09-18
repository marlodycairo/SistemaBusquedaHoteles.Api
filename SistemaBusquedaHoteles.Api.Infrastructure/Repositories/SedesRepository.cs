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

        public Locations GetSedeById(int id)
        {
            return context.Locations.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Locations> GetSedes()
        {
            return context.Locations
                .Include(p => p.Habitacion)
                .Include(r => r.Reservaciones)
                .ToList();
        }
    }
}
