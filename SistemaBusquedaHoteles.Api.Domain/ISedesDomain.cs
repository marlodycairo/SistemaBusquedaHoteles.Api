using SistemaBusquedaHoteles.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain
{
    public interface ISedesDomain
    {
        Task<IEnumerable<LocationsModel>> GetSedes();
        Task<LocationsModel> GetSedeById(int id);
    }
}
