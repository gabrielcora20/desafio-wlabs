using Microsoft.Extensions.Configuration;
using Serilog;
using Wlabs.Domain.Entities;
using Wlabs.Domain.Interfaces.Http;
using Wlabs.Domain.Interfaces.Redis;
using Wlabs.Domain.Interfaces.Repository;

namespace Wlabs.Infra.Data.Repository
{
    public class LocalizacaoApiCepRepository : ILocalizacaoApiCepRepository
    {
        private readonly IHttpRequester _httpRequester;
        private readonly IRedisCache _redisCache;
        private readonly IConfiguration _configuration;
        public LocalizacaoApiCepRepository(IConfiguration configuration, IHttpRequester httpRequester, IRedisCache redisCache)
        {
            _configuration = configuration;
            _httpRequester = httpRequester;
            _redisCache = redisCache;
        }
        public async Task<LocalizacaoApiCep> ObtemPorCep(string cep)
        {
            try
            {
                Log.Information($"Executando o método {nameof(ObtemPorCep)} na classe: {GetType().Name}");

                string key = string.Format("localizacao.apicep.{0}", cep);

                if (await _redisCache.ExisteInformacaoEmCache(key))
                    return await _redisCache.ObtemInformacaoEmCache<LocalizacaoApiCep>(key);

                return await _httpRequester.GetAndCache<LocalizacaoApiCep>(string.Format(_configuration["ApiCepEndpoint"], Convert.ToUInt64(cep).ToString(@"00000\-000")), key);
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Ocorreu um erro ao executar o método {nameof(ObtemPorCep)} na classe: {GetType().Name}");
                throw;
            }
        }
    }
}
