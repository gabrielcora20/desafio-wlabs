using FluentValidation.Results;
using MediatR;
using NetDevPack.Mediator;
using NetDevPack.Messaging;
using Serilog;

namespace Wlabs.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishEvent<TEvent>(TEvent @event) where TEvent : Event
        {
            Log.Information($"Executando o método {nameof(PublishEvent)} na classe: {GetType().Name}");

            Log.Information($"Evento {nameof(TEvent)} publicado");

            await _mediator.Publish(@event);
        }

        public async Task<ValidationResult> SendCommand<TCommand>(TCommand command) where TCommand : Command
        {
            Log.Information($"Executando o método {nameof(SendCommand)} na classe: {GetType().Name}");

            Log.Information($"Comando {nameof(TCommand)} enviado");

            return await _mediator.Send(command);
        }
    }
}