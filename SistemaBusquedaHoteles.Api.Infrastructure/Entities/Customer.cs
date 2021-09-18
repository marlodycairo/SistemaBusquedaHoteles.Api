using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string IDCliente { get; set; }
        public string Email { get; set; }

        public Reservation Reservation { get; set; }
    }
}
