using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Repository;
using Wlabs.Infra.CrossCutting.Json;

namespace Wlabs.Infra.Data.Repository
{
    public class LocalizacaoApiCepRepository : ILocalizacaoApiCepRepository
    {
        public async Task<LocalizacaoApiCep> ObtemPorCep(string cep)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://cdn.apicep.com/file/apicep/{0}.json", Convert.ToUInt64(cep).ToString(@"00000\-000")));
            return response.Deserialize<LocalizacaoApiCep>();
        }
    }
}
