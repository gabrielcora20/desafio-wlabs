using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using Wlabs.Domain.Events.Usuario;
using Wlabs.Domain.Interfaces.Repository;

namespace Wlabs.Domain.Commands.Usuario
{
    public class UsuarioCommandHandler : CommandHandler, 
        IRequestHandler<CadastraUsuarioCommand, ValidationResult>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ValidationResult> Handle(CadastraUsuarioCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var usuario = new Entities.Usuario(message.Nome, message.Email, message.Senha);

            if (await _usuarioRepository.ObtemPorEmail(usuario.Email) != null)
            {
                AddError("Um usuário com esse e-mail já foi cadastrado");
                return ValidationResult;
            }

            usuario.AddDomainEvent(new UsuarioCadastradoEvent(usuario.Id, usuario.Nome, usuario.Email, usuario.Senha));

            _usuarioRepository.Insere(usuario);

            return await Commit(_usuarioRepository.UnitOfWork);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
        }
    }
}
