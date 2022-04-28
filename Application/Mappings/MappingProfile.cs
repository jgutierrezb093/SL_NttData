using Application.Features.ClienteFeatures;
using Application.Features.ClienteFeatures.Commands.CreateCliente;
using Application.Features.ClienteFeatures.Queries;
using Application.Features.CuentaFeatures.Commands.CreateCuenta;
using Application.Features.CuentaFeatures.Queries;
using Application.Features.MovimientoFeatures.Commands.CreateMovimiento;
using Application.Features.MovimientoFeatures.Queries;
using AutoMapper;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateClienteCommand, Cliente>();
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();


            CreateMap<CreateCuentaCommand, Cuenta>();
            CreateMap<Cuenta, CuentaDto>();
            CreateMap<CuentaDto, Cuenta>();


            CreateMap<CreateMovimientoCommand, Movimiento>();
            CreateMap<Movimiento, MovimientoDto>();
            CreateMap<MovimientoDto, Movimiento>();
        }
    }
}
