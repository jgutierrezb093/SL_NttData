using FluentValidation;

namespace Application.Features.CuentaFeatures.Commands.UpdateCuenta
{
    public class UpdateCuentaCommandValidator : AbstractValidator<UpdateCuentaCommand>
    {
        public UpdateCuentaCommandValidator()
        {
            RuleFor(x => x.NumeroCuenta)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.SaldoInicial)
                .GreaterThan(0).WithMessage("Debe ser mayor de edad para registrarse");
            RuleFor(x => x.ClienteId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0).WithMessage("Cliente Inválido");
        }
    }
}