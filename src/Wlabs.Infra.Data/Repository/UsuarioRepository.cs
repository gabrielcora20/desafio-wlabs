using MongoDB.Driver;
using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Context;
using Wlabs.Domain.Interfaces.Repository;

namespace Wlabs.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IMongoContext context)
            :base(context)
        {  }
        
        public async Task<Usuario> ObtemPorEmail(string email)
        {
            var data = await DbSet.FindAsync(Builders<Usuario>.Filter.Eq("email", email));
            return data.SingleOrDefault();
        }
    }
}
