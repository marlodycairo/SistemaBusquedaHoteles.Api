using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SistemaBusquedaHoteles.Api.Domain.Models;

namespace SistemaBusquedaHoteles.Api.Domain.Validations
{
    public class CustomerModelValidator : AbstractValidator<CustomersModel>
    {
        public CustomerModelValidator()
        {
            RuleFor(p => p.IDCliente)
                .NotNull()
                .Length(0, 8)
                .WithMessage("Ingrese una identificación válida.")
                .NotEmpty().WithMessage("Debe ingresar su identificación.")
                .NotEqual("0");
                
                //.NotEqual(p => p.IDCliente).WithMessage("Cliente ya existe. Verifique la identificación.");

            RuleFor(p => p.NombreCliente)
                .NotNull()
                .NotEmpty().WithMessage("Debe ingresar su nombre completo.");

            RuleFor(p => p.Email)
                .NotNull()
                .NotEmpty().WithMessage("Debe ingresar su correo electrónico.");
        }
    }
}
