using SistemaBusquedaHoteles.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface ITipoAlojamientoApplication
    {
        Task<IEnumerable<RoomTypeModel>> GetAlojamientos();
        Task<RoomTypeModel> GetAlojamientoById(int id);
    }
}
