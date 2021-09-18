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
    public class TipoAlojamientoRepository : ITipoAlojamientoRepository
    {
        private readonly ApplicationDbContext context;

        public TipoAlojamientoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public TipoAlojamiento GetAlojamientoById(int id)
        {
            return context.TipoAlojamiento.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<TipoAlojamiento> GetAlojamientos()
        {
            return context.TipoAlojamiento
                .Include(p => p.Habitaciones)
                .Include(r => r.Reservacion)
                .ToList();
        }
    }
}
