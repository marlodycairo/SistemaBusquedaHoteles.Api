﻿using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository
{
    public interface IReservacionRepository
    {
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<Reservation> GetReservationById(int id);
        Task<Reservation> CreateReservation(Reservation reservacion);
        Task UpdateReservation(Reservation reservacion);
        Task DeleteReservation(int id);
        bool ReservationExists(int id);
    }
}
