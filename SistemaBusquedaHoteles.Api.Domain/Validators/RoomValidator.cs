using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SistemaBusquedaHoteles.Api.Domain.Models;
using SistemaBusquedaHoteles.Api.Domain.QueryFilters;

namespace SistemaBusquedaHoteles.Api.Domain.Validators
{
    public class RoomValidator : AbstractValidator<RoomModel>
    {
        public RoomValidator()
        {
            RuleFor(p => p.Estado).NotEmpty().WithMessage("Debe ingresar un estado.");
        }
    }
}
