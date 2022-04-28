
using FluentValidation;

namespace Application.Features.MovimientoFeatures.Commands.CreateMovimiento
{
    public class CreateMovimientoCommandValidator : AbstractValidator<CreateMovimientoCommand>
    {
        public CreateMovimientoCommandValidator()
        {
            RuleFor(x => x.CuentaId)
                .GreaterThan(0).WithMessage("Cuenta inválida");
        }
    }
}
