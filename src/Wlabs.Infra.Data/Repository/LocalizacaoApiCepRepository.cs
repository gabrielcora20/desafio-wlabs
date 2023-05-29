using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Http;
using Wlabs.Domain.Interfaces.Repository;

namespace Wlabs.Infra.Data.Repository
{
    public class LocalizacaoApiCepRepository : ILocalizacaoApiCepRepository
    {
        private readonly IHttpRequester _httpRequester;
        public LocalizacaoApiCepRepository(IHttpRequester httpRequester)
        {
            _httpRequester = httpRequester;
        }
        public async Task<LocalizacaoApiCep> ObtemPorCep(string cep)
        {
            return await _httpRequester.Get<LocalizacaoApiCep>(string.Format("https://cdn.apicep.com/file/apicep/{0}.json", Convert.ToUInt64(cep).ToString(@"00000\-000")));
        }
    }
}
