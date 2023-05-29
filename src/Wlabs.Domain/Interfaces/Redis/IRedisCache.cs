namespace Wlabs.Domain.Interfaces.Redis
{
    public interface IRedisCache
    {
        Task<string> ObtemInformacaoEmCache(string key);
        Task<TEntity> ObtemInformacaoEmCache<TEntity>(string key) where TEntity : class;
        Task<bool> ExisteInformacaoEmCache(string key);
        void CriaInformacaoEmCache(string key, string informacao);
        void CriaInformacaoEmCache<TEntity>(string key, TEntity informacao) where TEntity : class;
    }
}
