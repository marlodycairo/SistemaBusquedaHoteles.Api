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
        public Sedes GetSedeById(int id)
        {
            return context.Sedes.Find(id);
        }

        public IEnumerable<Sedes> GetSedes()
        {
            return context.Sedes.ToList();
        }
    }
}
