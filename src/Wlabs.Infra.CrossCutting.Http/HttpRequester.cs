using Serilog;
using Wlabs.Infra.CrossCutting.Http.Interfaces;
using Wlabs.Infra.CrossCutting.Json;
using Wlabs.Infra.CrossCutting.Redis.Interfaces;

namespace Wlabs.Infra.CrossCutting.Http
{
    public class HttpRequester : IHttpRequester
    {
        private readonly IRedisCache _redisCache;
        public HttpRequester(IRedisCache redisCache)
        {
            _redisCache = redisCache;
        }
        public async Task<TEntity> Get<TEntity>(string url) where TEntity : class
        {
            try
            {
                Log.Information($"Executando o método {nameof(Get)} na classe: {GetType().Name}");

                HttpClient httpClient = new HttpClient();
                var response = await httpClient.GetStringAsync(url);
                return response.Deserialize<TEntity>();
            }
            catch(Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(Get)} na classe: {GetType().Name}");
                throw;
            }
        }

        public async Task<TEntity> GetAndCache<TEntity>(string url, string cacheKey) where TEntity : class
        {
            try
            {
                Log.Information($"Executando o método {nameof(GetAndCache)} na classe: {GetType().Name}");

                TEntity responseEntity = await Get<TEntity>(url);
                _redisCache.CriaInformacaoEmCache(cacheKey, responseEntity);
                return responseEntity;
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(GetAndCache)} na classe: {GetType().Name}");
                throw;
            }
        }
    }
}
