using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class ResponseModel
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public int RateId { get; set; }
        public string Temporada { get; set; }
        public double Precio { get; set; }

        public RoomTypeModel RoomTypeModel { get; set; }
        public RatesModel RatesModel { get; set; }
        public RoomModel RoomModel { get; set; }
    }
}
