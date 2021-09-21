using Microsoft.EntityFrameworkCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
using SistemaBusquedaHoteles.Api.Infrastructure.Tasks.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories
{
    public class ReservacionRepository : IReservacionRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservacionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation> CreateReservation(Reservation reservacion)
        {
            if (ReservationExists(reservacion.Id))
            {
            }

            await _context.Reservation.AddAsync(reservacion);
            await _context.SaveChangesAsync();

            return reservacion;
        }

        public async Task DeleteReservation(int id)
        {
            Reservation reserva = await _context.Reservation.FirstOrDefaultAsync(p => p.Id == id);

            if (ReservationExists(id))
            {
            }
            _context.Remove(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _context.Reservation.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _context.Reservation
                .Include(p => p.Locations)
                .Include(p => p.Rates)
                .Include(p => p.Customers)
                .Include(p => p.Room)
                .ToListAsync();
        }

        public async Task<Reservation> UpdateReservation(Reservation reservation)
        {
            _context.Update(reservation);
            await _context.SaveChangesAsync();
            return reservation;
        }

        public bool ReservationExists(int id)
        {
            return _context.Reservation.Any(p => p.Id == id);
        }
    }
}
