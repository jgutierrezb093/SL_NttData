using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClienteFeatures.Queries
{
    public class GetClientesListQuery : IRequest<IEnumerable<ClienteDto>?>
    {
        public class GetAllClientesQueryHandler : IRequestHandler<GetClientesListQuery, IEnumerable<ClienteDto>?>
        {
            private readonly IClienteRepository _clienteRepository;
            private readonly IMapper _mapper;

            public GetAllClientesQueryHandler(IClienteRepository clienteRepository,
                IMapper mapper)
            {
                this._clienteRepository = clienteRepository;
                this._mapper =  mapper;
            }

            public async Task<IEnumerable<ClienteDto>?> Handle(GetClientesListQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<ClienteDto>? clientesDto = null;

                var clientes = await _clienteRepository.GetAsync();

                if (clientes != null)
                    clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientes);

                return clientesDto;
            }
        }

    }
}
