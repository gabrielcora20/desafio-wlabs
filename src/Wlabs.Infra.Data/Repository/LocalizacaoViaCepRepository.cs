using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Repository;
using Wlabs.Infra.CrossCutting.Json;

namespace Wlabs.Infra.Data.Repository
{
    public class LocalizacaoViaCepRepository : ILocalizacaoViaCepRepository
    {
        public async Task<LocalizacaoViaCep> ObtemPorCep(string cep)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://viacep.com.br/ws/{0}/json/", cep));
            return response.Deserialize<LocalizacaoViaCep>();
        }
    }
}
