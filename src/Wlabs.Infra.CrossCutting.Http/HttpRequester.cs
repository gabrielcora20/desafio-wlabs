using Wlabs.Domain.Interfaces.Http;
using Wlabs.Domain.Interfaces.Redis;
using Wlabs.Infra.CrossCutting.Json;

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
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);
            return response.Deserialize<TEntity>();
        }

        public async Task<TEntity> GetAndCache<TEntity>(string url, string cacheKey) where TEntity : class
        {
            TEntity responseEntity = await Get<TEntity>(url);
            _redisCache.CriaInformacaoEmCache(cacheKey, responseEntity);
            return responseEntity;
        }
    }
}
