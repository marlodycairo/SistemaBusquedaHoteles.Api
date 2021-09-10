using SistemaBusquedaHoteles.Api.Application;
using SistemaBusquedaHoteles.Api.Domain;
using SistemaBusquedaHoteles.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.ApplicationServices
{
    public class BuscadorApplicationServices : IBuscadorApplication
    {
        private readonly IBuscadorDomain reservaDomain;

        public BuscadorApplicationServices(IBuscadorDomain reservaDomain)
        {
            this.reservaDomain = reservaDomain;
        }

        public IEnumerable<HabitacionesViewModel> ConsultarAlojamiento(string buscar)
        {
            return reservaDomain.ConsultarAlojamiento(buscar);
        }
    }
}
