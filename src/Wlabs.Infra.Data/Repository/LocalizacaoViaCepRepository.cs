using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Http;
using Wlabs.Domain.Interfaces.Repository;

namespace Wlabs.Infra.Data.Repository
{
    public class LocalizacaoViaCepRepository : ILocalizacaoViaCepRepository
    {
        private readonly IHttpRequester _httpRequester;
        public LocalizacaoViaCepRepository(IHttpRequester httpRequester)
        {
            _httpRequester = httpRequester;
        }
        public async Task<LocalizacaoViaCep> ObtemPorCep(string cep)
        {
            return await _httpRequester.Get<LocalizacaoViaCep>(string.Format("https://viacep.com.br/ws/{0}/json/", cep));
        }
    }
}
