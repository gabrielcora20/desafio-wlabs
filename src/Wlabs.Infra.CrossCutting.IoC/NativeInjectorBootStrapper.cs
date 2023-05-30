using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;
using Serilog;
using Wlabs.Application.Interfaces;
using Wlabs.Application.Services;
using Wlabs.Domain.Commands.Usuario;
using Wlabs.Domain.Events.Usuario;
using Wlabs.Domain.Interfaces.Repository;
using Wlabs.Infra.CrossCutting.Bus;
using Wlabs.Infra.CrossCutting.Http;
using Wlabs.Infra.CrossCutting.Http.Interfaces;
using Wlabs.Infra.CrossCutting.Jwt;
using Wlabs.Infra.CrossCutting.Jwt.Interfaces;
using Wlabs.Infra.CrossCutting.Redis;
using Wlabs.Infra.CrossCutting.Redis.Interfaces;
using Wlabs.Infra.Data.Context;
using Wlabs.Infra.Data.Interfaces;
using Wlabs.Infra.Data.Repository;

namespace Wlabs.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            Log.Information($"Executando o método {nameof(RegisterServices)} na classe: {typeof(NativeInjectorBootStrapper).Name}");

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IRedisCache, RedisCache>();

            services.AddScoped<IHttpRequester, HttpRequester>();

            services.AddScoped<IJwtUtils, JwtUtils>();

            // Application
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();
            services.AddScoped<ILocalizacaoAppService, LocalizacaoAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<UsuarioCadastradoEvent>, UsuarioEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CadastraUsuarioCommand, ValidationResult>, UsuarioCommandHandler>();

            // Infra - Data
            services.AddScoped<IMongoContext, MongoContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ILocalizacaoViaCepRepository, LocalizacaoViaCepRepository>();
            services.AddScoped<ILocalizacaoApiCepRepository, LocalizacaoApiCepRepository>();
            services.AddScoped<ILocalizacaoAwesomeApiRepository, LocalizacaoAwesomeApiRepository>();
        }
    }
}