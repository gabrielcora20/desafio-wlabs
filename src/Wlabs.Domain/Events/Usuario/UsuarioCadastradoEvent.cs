using NetDevPack.Messaging;

namespace Wlabs.Domain.Events.Usuario
{
    public class UsuarioCadastradoEvent : Event
    {
        public UsuarioCadastradoEvent(string id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        public string Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Senha { get; protected set; }
    }
}
