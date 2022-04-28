using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Enums;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClienteFeatures.Commands.CreateCliente
{
    public class CreateClienteCommand : IRequest<long>
    {
        public string? Nombre { get; set; }
        public Generos Genero { get; set; }
        public short Edad { get; set; }
        public string? Identificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Contrasena { get; set; }
        public bool Estado { get; set; }

        public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, long>
        {
            private readonly IClienteRepository _clienteRepository;
            private readonly IMapper _mapper;

            public CreateClienteCommandHandler(IClienteRepository clienteRepository,
                IMapper mapper)
            {
                this._clienteRepository = clienteRepository;
                this._mapper = mapper;
            }

            public async Task<long> Handle(CreateClienteCommand command, CancellationToken cancellationToken)
            {
                var cliente = _mapper.Map<Cliente>(command);

                await _clienteRepository.AddAsync(cliente);

                return cliente.Id;
            }
        }
    }
}
