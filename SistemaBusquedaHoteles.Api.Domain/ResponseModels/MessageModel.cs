using SistemaBusquedaHoteles.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Domain.ResponseModels
{
    public class MessageModel
    {
        public string FieldName { get; set; }
        public string Response { get; set; }
        public CustomersModel CustomersModel { get; set; }
    }
}
