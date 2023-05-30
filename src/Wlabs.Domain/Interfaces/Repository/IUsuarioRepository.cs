using Wlabs.Domain.Entities;

namespace Wlabs.Domain.Interfaces.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<Usuario> ObtemPorEmail(string email);
        Task<Usuario> ObtemPorEmailESenha(string email, string senha);
    }
}
