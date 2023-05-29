using Microsoft.Extensions.Caching.Distributed;
using Wlabs.Domain.Interfaces.Redis;
using Wlabs.Infra.CrossCutting.Json;

namespace Wlabs.Infra.CrossCutting.Redis
{
    public class RedisCache : IRedisCache
    {
        private readonly IDistributedCache _cache;
        public RedisCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task<string> ObtemInformacaoEmCache(string key)
        {
            try
            {
                return await _cache.GetStringAsync(key);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public async Task<TEntity> ObtemInformacaoEmCache<TEntity>(string key) where TEntity : class
        {
            try
            {
                return (await ObtemInformacaoEmCache(key))?.Deserialize<TEntity>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
        public async Task<bool> ExisteInformacaoEmCache(string key) => !string.IsNullOrEmpty(await ObtemInformacaoEmCache(key));
        public async void CriaInformacaoEmCache(string key, string informacao)
        {
            try
            {
                await _cache.SetStringAsync(key, informacao);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void CriaInformacaoEmCache<TEntity>(string key, TEntity informacao) where TEntity : class
        {
            try
            {
                CriaInformacaoEmCache(key, informacao.Serialize());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
