using Wlabs.Domain.Interfaces.Http;
using Wlabs.Infra.CrossCutting.Json;

namespace Wlabs.Infra.CrossCutting.Http
{
    public class HttpRequester : IHttpRequester
    {
        public async Task<TEntity> Get<TEntity>(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(url);
            return response.Deserialize<TEntity>();
        }
    }
}
