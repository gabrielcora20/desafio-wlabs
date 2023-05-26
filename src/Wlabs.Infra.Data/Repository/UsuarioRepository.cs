using NetDevPack.Data;
using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces;

namespace Wlabs.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObtemPorEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
