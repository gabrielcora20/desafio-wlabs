using MediatR;

namespace Wlabs.Domain.Events.Usuario
{
    public class UsuarioEventHandler : INotificationHandler<UsuarioCadastradoEvent>
    {
        public Task Handle(UsuarioCadastradoEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
