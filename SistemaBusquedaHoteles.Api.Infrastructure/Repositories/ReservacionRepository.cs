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
    public class ReservacionRepository : IReservacionRepository
    {
        private readonly ApplicationDbContext context;

        public ReservacionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Reservacion CreateReservacion(Reservacion reservacion)
        {
            context.Reservacion.Add(reservacion);
            context.SaveChanges();

            return reservacion;
        }

        public void DeleteReservacion(int id)
        {
            var reserva = context.Reservacion.FirstOrDefault(p => p.Id == id);

            context.Remove(reserva).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public Reservacion GetReservaById(int id)
        {
            return context.Reservacion.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Reservacion> GetReservaciones()
        {
            return context.Reservacion
                .Include(p => p.Sede)
                .Include(p => p.TAlojamiento)
                .Include(p => p.Tarifa)
                .Include(p => p.Cliente)
                .Include(p => p.Habitacion)
                .ToList();
        }

        public Reservacion UpdateReservacion(Reservacion reservacion)
        {
            context.Entry(reservacion).State = EntityState.Modified;
            context.SaveChanges();

            return reservacion;
        }
    }
}
