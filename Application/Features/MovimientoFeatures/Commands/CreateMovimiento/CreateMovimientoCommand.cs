using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovimientoFeatures.Commands.CreateMovimiento
{
    public class CreateMovimientoCommand : IRequest<string>
    {
        public DateTime Fecha { get; set; }
        public TipoMovimientos TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public long CuentaId { get; set; }

        public class CreateMovimientoCommandHandler : IRequestHandler<CreateMovimientoCommand, string>
        {
            private readonly IConfiguration _configuration;
            private readonly ICuentaRepository _cuentaRepository;
            private readonly IMovimientoRepository _movimientoRepository;
            private readonly IMapper _mapper;

            public CreateMovimientoCommandHandler(IConfiguration configuration,
                ICuentaRepository cuentaRepository,
                IMovimientoRepository movimientoRepository,
                IMapper mapper
                )
            {
                this._movimientoRepository = movimientoRepository;
                this._cuentaRepository = cuentaRepository;
                this._configuration = configuration;
                this._mapper = mapper;
            }

            public async Task<string> Handle(CreateMovimientoCommand command, CancellationToken cancellationToken)
            {
                var cuenta = await _cuentaRepository.GetAsync(command.CuentaId);

                if(cuenta != null)
                {
                    if (command.TipoMovimiento == TipoMovimientos.Debito)
                    {
                        if (await ValidateMontoMax(command.CuentaId, long.Parse(command.Fecha.ToString("yyyyMMdd")), command.Valor))
                            return "Cupo diario Excedido";

                        if (cuenta.SaldoInicial == 0)
                            return "Saldo no disponible";
                    }

                    decimal saldo = cuenta.SaldoInicial + command.Valor;

                    var movimiento = _mapper.Map<Movimiento>(command);
                    movimiento.Saldo = saldo;

                    await _movimientoRepository.AddAsync(movimiento);

                    return "Ok";
                }
                else
                    return "Cuenta Inválida";
            }

            private async Task<bool> ValidateMontoMax(long cuentaId, long fecha, decimal valor)
            {
                decimal montoMaximo = decimal.Parse(this._configuration["MontoMaximo"]);
                
                var movimientos = await _movimientoRepository.FindAsync(x => x.CuentaId == cuentaId && x.TipoMovimiento == TipoMovimientos.Debito);

                var debitoDia = movimientos.Where(x => long.Parse(x.Fecha.ToString("yyyyMMdd")) == fecha).Sum(x => x.Valor);

                return ((-(debitoDia + valor)) > (montoMaximo));
            }
        }
    
    }
}
