using Microsoft.Extensions.Caching.Distributed;
using Serilog;
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
                Log.Information($"Executando o método {nameof(ObtemInformacaoEmCache)} na classe: {GetType().Name}");

                return await _cache.GetStringAsync(key);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(ObtemInformacaoEmCache)} na classe: {GetType().Name}");
                return null;
            }
        }

        public async Task<TEntity> ObtemInformacaoEmCache<TEntity>(string key) where TEntity : class
        {
            try
            {
                Log.Information($"Executando o método {nameof(ObtemInformacaoEmCache)} na classe: {GetType().Name}");

                return (await ObtemInformacaoEmCache(key))?.Deserialize<TEntity>();
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(ObtemInformacaoEmCache)} na classe: {GetType().Name}");
                return null;
            }
        }

        public async Task<bool> ExisteInformacaoEmCache(string key)
        {
            Log.Information($"Executando o método {nameof(ExisteInformacaoEmCache)} na classe: {GetType().Name}");

            return !string.IsNullOrEmpty(await ObtemInformacaoEmCache(key));
        }

        public async void CriaInformacaoEmCache(string key, string informacao)
        {
            try
            {
                Log.Information($"Executando o método {nameof(CriaInformacaoEmCache)} na classe: {GetType().Name}");

                await _cache.SetStringAsync(key, informacao);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(CriaInformacaoEmCache)} na classe: {GetType().Name}");
            }
        }

        public void CriaInformacaoEmCache<TEntity>(string key, TEntity informacao) where TEntity : class
        {
            try
            {
                Log.Information($"Executando o método {nameof(CriaInformacaoEmCache)} na classe: {GetType().Name}");

                CriaInformacaoEmCache(key, informacao.Serialize());
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(CriaInformacaoEmCache)} na classe: {GetType().Name}");
            }
        }
    }
}
