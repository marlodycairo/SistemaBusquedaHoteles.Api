using Microsoft.EntityFrameworkCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository;
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
                return new Reservation { Response = "El registro ya existe. Verifique e intente de nuevo." };
            }

            await _context.Reservations.AddAsync(reservacion);
            await _context.SaveChangesAsync();

            return reservacion;
        }

        public async Task DeleteReservation(int id)
        {
            Reservation reserva = _context.Reservations.FirstOrDefault(p => p.Id == id);

            if (ReservationExists(id))
            {
                new Reservation { Response = "Hubo un error. El registro no existe en la base de datos." };
            }
            _context.Remove(reserva);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _context.Reservations
                .Include(p => p.Locations)
                .Include(p => p.RoomType)
                .Include(p => p.Rates)
                .Include(p => p.Customer)
                .Include(p => p.Rooms)
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
            return _context.Reservations.Any(p => p.Id == id);
        }
    }
}
