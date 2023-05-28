using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Data;
using NetDevPack.Mediator;
using Wlabs.Application.Interfaces;
using Wlabs.Application.Services;
using Wlabs.Domain.Commands.Usuario;
using Wlabs.Domain.Events.Usuario;
using Wlabs.Domain.Interfaces.Context;
using Wlabs.Domain.Interfaces.Repository;
using Wlabs.Infra.CrossCutting.Bus;
using Wlabs.Infra.Data.Context;
using Wlabs.Infra.Data.Repository;

namespace Wlabs.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<UsuarioCadastradoEvent>, UsuarioEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CadastraUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();

            // Infra - Data
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }
    }
}