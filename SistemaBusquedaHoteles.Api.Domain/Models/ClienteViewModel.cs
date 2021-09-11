using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string IDCliente { get; set; }
        public string Email { get; set; }

        public ReservacionViewModel ReservacionModel { get; set; }
    }
}
