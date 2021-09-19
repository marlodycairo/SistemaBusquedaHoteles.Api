using SistemaBusquedaHoteles.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Application
{
    public interface ISedesApplication
    {
        Task<IEnumerable<Locations>> GetSedes();
        Task<Locations> GetSedeById(int id);
    }
}
