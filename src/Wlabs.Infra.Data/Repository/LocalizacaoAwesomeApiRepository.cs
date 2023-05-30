using Microsoft.Extensions.Configuration;
using Serilog;
using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Repository;
using Wlabs.Infra.CrossCutting.Http.Interfaces;
using Wlabs.Infra.CrossCutting.Redis.Interfaces;

namespace Wlabs.Infra.Data.Repository
{
    public class LocalizacaoAwesomeApiRepository : ILocalizacaoAwesomeApiRepository
    {
        private readonly IHttpRequester _httpRequester;
        private readonly IRedisCache _redisCache;
        private readonly IConfiguration _configuration;
        public LocalizacaoAwesomeApiRepository(IConfiguration configuration, IHttpRequester httpRequester, IRedisCache redisCache)
        {
            _configuration = configuration;
            _httpRequester = httpRequester;
            _redisCache = redisCache;
        }
        public async Task<LocalizacaoAwesomeApi> ObtemPorCep(string cep)
        {
            try
            {
                Log.Information($"Executando o método {nameof(ObtemPorCep)} na classe: {GetType().Name}");

                string key = string.Format("localizacao.awesomeapi.{0}", cep);

                if (await _redisCache.ExisteInformacaoEmCache(key))
                    return await _redisCache.ObtemInformacaoEmCache<LocalizacaoAwesomeApi>(key);

                return await _httpRequester.GetAndCache<LocalizacaoAwesomeApi>(string.Format(_configuration["AwesomeApiEndpoint"], cep), key);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(ObtemPorCep)} na classe: {GetType().Name}");
                throw;
            }
        }
    }
}
