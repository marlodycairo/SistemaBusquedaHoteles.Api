using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SistemaBusquedaHoteles.Api.Infrastructure.Entities;

namespace SistemaBusquedaHoteles.Api.Infrastructure.Validations
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.IDCliente).NotEmpty().WithMessage("Debe ingresar su identificación.");

        }
    }
}
