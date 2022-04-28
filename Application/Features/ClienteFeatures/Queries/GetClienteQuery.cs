using Application.Interfaces;
using Domain.Entity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.Features.ClienteFeatures.Queries
{
    public class GetClienteQuery : IRequest<ClienteDto?>
    {
        public long Id { get; set; }
        public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteQuery, ClienteDto?>
        {
            private readonly IClienteRepository _clienteRepository;
            private readonly IMapper _mapper;

            public GetClienteByIdQueryHandler(IClienteRepository clienteRepository,
                IMapper mapper)
            {
                this._clienteRepository = clienteRepository;
                this._mapper = mapper;
            }
            public async Task<ClienteDto?> Handle(GetClienteQuery query, CancellationToken cancellationToken)
            {
                ClienteDto? clienteDto = null;

                var cliente = await _clienteRepository.GetAsync(query.Id);
                
                if (cliente != null)
                    clienteDto = _mapper.Map<ClienteDto>(cliente);

                return clienteDto;
            }
        }
    }
}
