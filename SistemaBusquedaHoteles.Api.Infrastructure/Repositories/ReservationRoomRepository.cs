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
    public class ReservationRoomRepository : IReservationRoomRepository
    {
        private readonly ApplicationDbContext context;

        public ReservationRoomRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ReservationsRooms>> GetAllReservationRoom()
        {
            return await context.ReservationsRooms
                .Include(p => p.Reservations)
                .Include(r => r.Room)
                .ToListAsync();
        }
    }
}
