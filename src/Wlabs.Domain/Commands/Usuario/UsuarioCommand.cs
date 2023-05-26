using NetDevPack.Messaging;

namespace Wlabs.Domain.Commands.Usuario
{
    public abstract class UsuarioCommand: Command
    {
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Senha { get; protected set; }
    }
}
