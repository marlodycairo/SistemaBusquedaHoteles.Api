﻿using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface IReservationRoomApplication
    {
        Task<IEnumerable<ReservationRoomModel>> GetAllReservesRooms(ReservacionQueryFilter filter);
    }
}
