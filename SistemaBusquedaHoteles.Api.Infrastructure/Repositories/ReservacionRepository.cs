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
    public class ReservacionRepository : IReservacionRepository
    {
        private readonly ApplicationDbContext context;

        public ReservacionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Reservacion GetReservaById(int id)
        {
            return context.Reservacion.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Reservacion> GetReservaciones()
        {
            return context.Reservacion.ToList();
        }
    }
}
