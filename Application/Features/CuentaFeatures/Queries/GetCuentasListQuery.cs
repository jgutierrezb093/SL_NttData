using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CuentaFeatures.Queries
{
    public class GetCuentasListQuery : IRequest<IEnumerable<CuentaDto>?>
    {
        public class GetAllCuentasQueryHandler : IRequestHandler<GetCuentasListQuery, IEnumerable<CuentaDto>?>
        {
            private readonly ICuentaRepository _cuentaRepository;
            private readonly IMapper _mapper;
            
            public GetAllCuentasQueryHandler(ICuentaRepository cuentaRepository,
                IMapper mapper)
            {
                this._cuentaRepository = cuentaRepository;
                this._mapper = mapper;
            }

            public async Task<IEnumerable<CuentaDto>?> Handle(GetCuentasListQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<CuentaDto>? cuentaDto = null;

                var cuentas = await _cuentaRepository.GetAsync();

                if (cuentas != null)
                    cuentaDto = _mapper.Map<IEnumerable<CuentaDto>>(cuentas);

                return cuentaDto;
            }
        }
    }
}
