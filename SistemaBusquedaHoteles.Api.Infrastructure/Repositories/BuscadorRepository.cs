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
    public class BuscadorRepository : IBuscadorRepository
    {
        private readonly ApplicationDbContext context;

        public BuscadorRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Habitaciones> ConsultarAlojamiento(string buscar)
        {
            return context.Habitaciones.ToList();
        }
    }
}
