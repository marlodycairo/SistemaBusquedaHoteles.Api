using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Tasks.Constants
{
    public class Constants
    {
        public const string ResponseCreateReservationRepository = "El registro ya existe. Verifique e intente de nuevo.";
        public const string ResponseDeleteReservationRepository = "Hubo un error. El registro no existe en la base de datos.";
        public const string ErrorUpdateCustomer = "No se pudo actualizar. Verifique la identificación e intente de nuevo.";
}
}
