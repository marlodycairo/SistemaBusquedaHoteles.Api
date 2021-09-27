using Microsoft.EntityFrameworkCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Context;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Responses
{
    public class CustomerResponse
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string IDCliente { get; set; }
        public string Email { get; set; }
        public string Response { get; set; }
        public Customer Customers { get; set; }
    }
}
