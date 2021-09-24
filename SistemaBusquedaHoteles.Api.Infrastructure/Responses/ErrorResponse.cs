using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Responses
{
    public class ErrorResponse
    {
        public List<Error> Errors { get; set; } = new List<Error>();
    }
}
