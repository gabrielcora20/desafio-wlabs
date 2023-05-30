using MongoDB.Driver;
using Serilog;
using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Repository;
using Wlabs.Infra.Data.Interfaces;
using Wlabs.Infra.CrossCutting.Encryption;

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

        public async Task<Usuario> ObtemPorEmailESenha(string email, string senha)
        {
            try
            {
                Log.Information($"Executando o método {nameof(ObtemPorEmail)} na classe: {GetType().Name}");

                var data = await DbSet.FindAsync(u => u.Email == email && u.Senha == senha.Encrypt());
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
