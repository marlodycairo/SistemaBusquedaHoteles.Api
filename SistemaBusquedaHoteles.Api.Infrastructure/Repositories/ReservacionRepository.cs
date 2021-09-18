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
        private readonly ApplicationDbContext _context;

        public ReservacionRepository(ApplicationDbContext _context)
        {
            _context = _context;
        }

        public async Task<Reservation> CreateReservation(Reservation reservacion)
        {


            _context.Reservations.Add(reservacion);
            _context.SaveChanges();

            return reservacion;
        }

        public async Task DeleteReservation(int id)
        {
            var reserva = _context.Reservations.FirstOrDefault(p => p.Id == id);

            _context.Remove(reserva);
            _context.SaveChanges();
        }

        public async Task<Reservation> GetReservationById(int id)
        {
            return _context.Reservations.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return _context.Reservations
                .Include(p => p.Locations)
                .Include(p => p.RoomType)
                .Include(p => p.Rates)
                .Include(p => p.Customer)
                .Include(p => p.Rooms)
                .ToList();
        }

        public Task UpdateReservation(Reservation reservation)
        {
            _context.Update(reservation);
            _context.SaveChanges();

            return reservation;
        }

        public bool ReservationExists(int id)
        {
            return _context.Reservations.Any(p => p.Id == id);
        }


    }
}
