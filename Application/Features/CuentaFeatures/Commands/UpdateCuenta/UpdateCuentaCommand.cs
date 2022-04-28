using Application.Interfaces;
using Domain.Entity;
using Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CuentaFeatures.Commands.UpdateCuenta
{
    public class UpdateCuentaCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string? NumeroCuenta { get; set; }
        public TipoCuentas TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public long ClienteId { get; set; }

        public class UpdateCuentaCommandHandler : IRequestHandler<UpdateCuentaCommand, long>
        {
            private readonly ICuentaRepository _cuentaRepository;
            public UpdateCuentaCommandHandler(ICuentaRepository cuentaRepository)
            {
                _cuentaRepository = cuentaRepository;
            }

            public async Task<long> Handle(UpdateCuentaCommand command, CancellationToken cancellationToken)
            {
                var cuenta = await _cuentaRepository.GetAsync(command.Id);

                if (cuenta == null)
                    return default;
                else
                {
                    cuenta.Id = command.Id;
                    cuenta.NumeroCuenta = command.NumeroCuenta;
                    cuenta.TipoCuenta = command.TipoCuenta;
                    cuenta.SaldoInicial = command.SaldoInicial;
                    cuenta.Estado = command.Estado;
                    cuenta.ClienteId = command.ClienteId;
                    await _cuentaRepository.Update(cuenta);
                    return cuenta.Id;
                }
            }
        }
    }
}
