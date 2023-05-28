using Wlabs.Domain.Entities;

namespace Wlabs.Domain.Interfaces.Repository
{
    public interface ILocalizacaoViaCepRepository
    {
        Task<LocalizacaoViaCep> ObtemPorCep(string cep);
    }
}
