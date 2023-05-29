using MongoDB.Driver;
using Serilog;
using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Context;
using Wlabs.Domain.Interfaces.Repository;

namespace Wlabs.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IMongoContext context)
            : base(context)
        { }

        public async Task<Usuario> ObtemPorEmail(string email)
        {
            try
            {
                Log.Information($"Executando o método {nameof(ObtemPorEmail)} na classe: {GetType().Name}");

                var data = await DbSet.FindAsync(Builders<Usuario>.Filter.Eq("email", email));
                return data.SingleOrDefault();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(ObtemPorEmail)} na classe: {GetType().Name}");
                throw;
            }
        }
    }
}
