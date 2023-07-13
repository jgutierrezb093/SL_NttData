using Application.Features.ClienteFeatures.Commands.CreateCliente;
using Application.Features.ClienteFeatures.Commands.UpdateCliente;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMvc().AddFluentValidation();

            services.AddTransient<IValidator<CreateClienteCommand>, CreateClienteCommandValidator>();
            services.AddTransient<IValidator<UpdateClienteCommand>, UpdateClienteCommandValidator>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
