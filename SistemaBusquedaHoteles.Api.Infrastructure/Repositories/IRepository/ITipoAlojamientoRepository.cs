using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository
{
    public interface ITipoAlojamientoRepository
    {
        Task<IEnumerable<RoomTypes>> GetAlojamientos();
        Task<RoomTypes> GetAlojamientoById(int id);
    }
}
