﻿using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;
using Wlabs.Application.Interfaces;
using Wlabs.Application.Services;
using Wlabs.Domain.Commands.Usuario;
using Wlabs.Domain.Events.Usuario;
using Wlabs.Domain.Interfaces.Context;
using Wlabs.Domain.Interfaces.Http;
using Wlabs.Domain.Interfaces.Repository;
using Wlabs.Infra.CrossCutting.Bus;
using Wlabs.Infra.CrossCutting.Http;
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

            services.AddScoped< IHttpRequester, HttpRequester>();

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
        }
    }
}