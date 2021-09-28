using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Repositories.IRepository
{
    public interface IRoomsRepository
    {
        Task<IEnumerable<Rooms>> GetAll();
        Task<Rooms> GetById(int id);
        Task<Rooms> Create(Rooms habitaciones);
        Task<Rooms> Update(Rooms habitaciones);
        Task Delete(int id);
    }
}
