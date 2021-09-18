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

        public async Task<Reservation> CreateReservacion(Reservation reservacion)
        {


            context.Reservation.Add(reservacion);
            context.SaveChanges();

            return reservacion;
        }

        public async Task DeleteReservacion(int id)
        {
            var reserva = context.Reservation.FirstOrDefault(p => p.Id == id);

            context.Remove(reserva);
            context.SaveChanges();
        }

        public Reservation GetReservaById(int id)
        {
            return context.Reservation.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Reservation> GetReservaciones()
        {
            return context.Reservation
                .Include(p => p.Sede)
                .Include(p => p.TAlojamiento)
                .Include(p => p.Tarifa)
                .Include(p => p.Cliente)
                .Include(p => p.Habitacion)
                .ToList();
        }

        public Reservation UpdateReservacion(Reservation reservacion)
        {

            context.Update(reservacion);
            context.SaveChanges();

            return reservacion;
        }

        private bool ReservationExists(int id)
        {
            return context.Reservation.Any(p => p.Id == id);
        }
    }
}
