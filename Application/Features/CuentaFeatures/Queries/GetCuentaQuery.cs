using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CuentaFeatures.Queries
{
    public class GetCuentaQuery : IRequest<CuentaDto?>
    {
        public long Id { get; set; }
        public class GetCuentaByIdQueryHandler : IRequestHandler<GetCuentaQuery, CuentaDto?>
        {
            private readonly ICuentaRepository _cuentaRepository;
            private readonly IMapper _mapper;

            public GetCuentaByIdQueryHandler(ICuentaRepository cuentaRepository,
                IMapper mapper)
            {
                _cuentaRepository = cuentaRepository;
                this._mapper = mapper;
            }

            public async Task<CuentaDto?> Handle(GetCuentaQuery query, CancellationToken cancellationToken)
            {
                CuentaDto? cuentaDto = null;

                var cuenta = await _cuentaRepository.GetAsync(query.Id);

                if (cuenta != null)
                    cuentaDto = _mapper.Map<CuentaDto>(cuenta);

                return cuentaDto;
            }
        }

    }
}
