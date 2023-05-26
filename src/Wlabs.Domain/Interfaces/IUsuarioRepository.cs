using NetDevPack.Data;
using Wlabs.Domain.Entities;

namespace Wlabs.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepository<Usuario>, IRepositoryBase<Usuario>
    {
        Task<Usuario> ObtemPorEmail(string email);
    }
}
