using SistemaBusquedaHoteles.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface IReservationRoomDomain
    {
        Task<IEnumerable<ReservationRoomModel>> GetAllReservesRooms();
    }
}
