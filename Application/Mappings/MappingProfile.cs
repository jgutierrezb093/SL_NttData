using Application.Features.ClienteFeatures.Commands.CreateCliente;
using Application.Features.ClienteFeatures.Queries;
using AutoMapper;
using Domain.Entity;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateClienteCommand, Cliente>();
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
        }
    }
}
