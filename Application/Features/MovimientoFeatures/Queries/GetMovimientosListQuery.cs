using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovimientoFeatures.Queries
{
    public class GetMovimientosListQuery : IRequest<IEnumerable<MovimientoDto>?>
    {
        public class GetAllMovimientosQueryHandler : IRequestHandler<GetMovimientosListQuery, IEnumerable<MovimientoDto>?>
        {
            private readonly IMovimientoRepository _movimientoRepository;
            private readonly IMapper _mapper;

            public GetAllMovimientosQueryHandler(IMovimientoRepository movimientoRepository,
                IMapper mapper)
            {
                this._movimientoRepository = movimientoRepository;
                this._mapper = mapper;
            }

            public async Task<IEnumerable<MovimientoDto>?> Handle(GetMovimientosListQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<MovimientoDto>? movimientosDto = null;

                var movimientos = await _movimientoRepository.GetAsync();

                if (movimientos != null)
                    movimientosDto = _mapper.Map<IEnumerable<MovimientoDto>>(movimientos);

                return movimientosDto;
            }
        }
    }
}
