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

        public Rates GetTarifaById(int id)
        {
            var tarifa = context.Tarifas.FirstOrDefault(p => p.Id == id);

            return tarifa;
        }

        public IEnumerable<Rates> GetTarifas()
        {
            return context.Tarifas
                .Include(p => p.Alojamiento)
                .Include(r => r.Reservacion)
                .ToList();
        }
    }
}
