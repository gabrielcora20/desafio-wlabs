using Wlabs.Domain.Entities;

namespace Wlabs.Domain.Interfaces.Repository
{
    public interface ILocalizacaoApiCepRepository
    {
        Task<LocalizacaoApiCep> ObtemPorCep(string cep);
    }
}
