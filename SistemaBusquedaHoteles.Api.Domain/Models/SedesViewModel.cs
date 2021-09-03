using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.Models
{
    public class SedesViewModel
    {
        public string Ciudad { get; set; }
        public int CupoMaximo { get; set; }
    }
}
