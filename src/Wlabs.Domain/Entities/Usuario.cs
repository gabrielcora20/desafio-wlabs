using NetDevPack.Domain;

namespace Wlabs.Domain.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public Usuario(string id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public Usuario() {}
    }
}
