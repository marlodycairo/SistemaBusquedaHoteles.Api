using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Responses
{
    public class ResponseCustomer
    {
        public string FieldName { get; set; }
        public string Response { get; set; }
        public Customer Customer { get; set; }
    }
}
