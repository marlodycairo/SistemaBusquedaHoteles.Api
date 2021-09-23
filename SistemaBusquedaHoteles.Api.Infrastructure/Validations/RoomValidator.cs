using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Validations
{
    public class RoomValidator : AbstractValidator<Rooms>
    {
        public RoomValidator()
        {
            
        }
    }
}
