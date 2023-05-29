using Microsoft.Extensions.Configuration;
using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Http;
using Wlabs.Domain.Interfaces.Redis;
using Wlabs.Domain.Interfaces.Repository;

namespace Wlabs.Infra.Data.Repository
{
    public class LocalizacaoViaCepRepository : ILocalizacaoViaCepRepository
    {
        private readonly IHttpRequester _httpRequester;
        private readonly IRedisCache _redisCache;
        private readonly IConfiguration _configuration;

        public LocalizacaoViaCepRepository(IConfiguration configuration, IHttpRequester httpRequester, IRedisCache redisCache)
        {
            _configuration = configuration;
            _httpRequester = httpRequester;
            _redisCache = redisCache;
        }
        public async Task<LocalizacaoViaCep> ObtemPorCep(string cep)
        {
            string key = string.Format("localizacao.viacep.{0}", cep);

            if (await _redisCache.ExisteInformacaoEmCache(key))
                return await _redisCache.ObtemInformacaoEmCache<LocalizacaoViaCep>(key);

            return await _httpRequester.GetAndCache<LocalizacaoViaCep>(string.Format(_configuration["ViaCepEndpoint"], cep), key);
        }
    }
}
