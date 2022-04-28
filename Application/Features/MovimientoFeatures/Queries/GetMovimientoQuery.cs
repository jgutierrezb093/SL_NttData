using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.MovimientoFeatures.Queries
{
    public class GetMovimientoQuery : IRequest<MovimientoDto?>
    {
        public long Id { get; set; }

        public class GetMovimientoByIdQueryHandler : IRequestHandler<GetMovimientoQuery, MovimientoDto?>
        {
            private readonly IMovimientoRepository _movimientoRepository;
            private readonly IMapper _mapper;

            public GetMovimientoByIdQueryHandler(IMovimientoRepository movimientoRepository,
                IMapper mapper)
            {
                this._movimientoRepository = movimientoRepository;
                this._mapper = mapper;
            }
            public async Task<MovimientoDto?> Handle(GetMovimientoQuery query, CancellationToken cancellationToken)
            {
                MovimientoDto? movimientoDto = null;

                var movimiento = await _movimientoRepository.GetAsync(query.Id);

                if (movimiento != null)
                    movimientoDto = _mapper.Map<MovimientoDto>(movimiento);

                return movimientoDto;
            }
        }
    }
}
