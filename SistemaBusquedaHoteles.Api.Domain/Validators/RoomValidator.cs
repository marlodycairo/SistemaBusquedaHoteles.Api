using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SistemaBusquedaHoteles.Api.Domain.Models;

namespace SistemaBusquedaHoteles.Api.Domain.Validators
{
    public class RoomValidator : AbstractValidator<RoomModel>
    {
        public RoomValidator()
        {
            RuleFor(p => p.)
        }
    }
}
