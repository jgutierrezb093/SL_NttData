using Application.Interfaces;
using Domain.Entity;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ReportesFeatures.Queries
{
    public class GetReportesByFechaQuery : IRequest<IEnumerable<ReporteByFechaDto>?>
    {
        public DateTime Fecha { get; set; }

        public class GetReportesByFechaQueryHandler : IRequestHandler<GetReportesByFechaQuery, IEnumerable<ReporteByFechaDto>?>
        {
            private readonly IMovimientoRepository _movimientoRepository;
            private readonly ICuentaRepository _cuentaRepository;
            private readonly IClienteRepository _clienteRepository;

            public GetReportesByFechaQueryHandler(
                IMovimientoRepository movimientoRepository,
                ICuentaRepository cuentaRepository,
                IClienteRepository clienteRepository
                )
            {
                _movimientoRepository = movimientoRepository;
                _cuentaRepository = cuentaRepository;
                _clienteRepository = clienteRepository;
            }

            public async Task<IEnumerable<ReporteByFechaDto>?> Handle(GetReportesByFechaQuery query, CancellationToken cancellationToken)
            {
                List<ReporteByFechaDto>? reporte = null;

                var movimientos = await _movimientoRepository.GetAsync();
                movimientos = movimientos?.Where(x => x.Fecha.ToString("yyyyMMdd") == query.Fecha.ToString("yyyyMMdd"));

                if (movimientos != null)
                {
                    reporte = new List<ReporteByFechaDto>();

                    foreach (var movimiento in movimientos)
                    {
                        var cuenta = await _cuentaRepository.GetAsync(movimiento.CuentaId);

                        Cliente? cliente = null;

                        if (cuenta != null)
                            cliente = await _clienteRepository.GetAsync(cuenta.ClienteId);

                        reporte.Add(new ReporteByFechaDto
                        {
                            Fecha = movimiento.Fecha.ToString("dd/MM/yyyy"),
                            Cliente = cliente?.Nombre,
                            NumeroCuenta = cuenta?.NumeroCuenta,
                            Tipo = cuenta?.TipoCuenta == TipoCuentas.Ahorro ? "Ahorro" : "Corriente",
                            SaldoInicial = cuenta?.SaldoInicial,
                            Estado = cuenta?.Estado,
                            Movimiento = movimiento?.Valor,
                            SaldoDisponible = movimiento?.Saldo
                        });
                    }
                }

                return reporte;
            }
        }
    }
}
