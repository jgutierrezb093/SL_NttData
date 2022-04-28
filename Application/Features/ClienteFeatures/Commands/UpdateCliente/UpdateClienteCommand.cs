using Application.Interfaces;
using AutoMapper;
using Domain.Entity;
using Domain.Enums;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClienteFeatures.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public Generos Genero { get; set; }
        public short Edad { get; set; }
        public string? Identificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Contrasena { get; set; }
        public bool Estado { get; set; }


        public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, long>
        {
            private readonly IClienteRepository _clienteRepository;
            
            public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
            {
                this._clienteRepository = clienteRepository;
            }

            public async Task<long> Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
            {
                var cliente = await _clienteRepository.GetAsync(command.Id);

                if (cliente == null)
                {
                    return default;
                }
                else
                {
                    cliente.Id = command.Id;
                    cliente.Nombre = command.Nombre;
                    cliente.Genero = command.Genero;
                    cliente.Edad = command.Edad;
                    cliente.Identificacion = command.Identificacion;
                    cliente.Direccion = command.Direccion;
                    cliente.Telefono = command.Telefono;
                    cliente.Contrasena = command.Contrasena;
                    cliente.Estado = command.Estado;
                    await _clienteRepository.Update(cliente);
                    return cliente.Id;
                }
            }
        }
    }
}
