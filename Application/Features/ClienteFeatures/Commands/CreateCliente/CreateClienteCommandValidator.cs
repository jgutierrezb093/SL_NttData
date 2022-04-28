using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ClienteFeatures.Commands.CreateCliente
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(x => x.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Edad)
                .Must(IsOver18).WithMessage("Debe ser mayor de edad para registrarse");
            RuleFor(x => x.Identificacion)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Direccion)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Contrasena)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }

        private bool IsOver18(short edad)
        {
            return edad >= 18;
        }
    }
}
