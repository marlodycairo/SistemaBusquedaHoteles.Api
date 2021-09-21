using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class RoomTypeModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ReservationsModel ReservationsModels { get; set; }
        public RatesModel RatesModels { get; set; }
    }
}
