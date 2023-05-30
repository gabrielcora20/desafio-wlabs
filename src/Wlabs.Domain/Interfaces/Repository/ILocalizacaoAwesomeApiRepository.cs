using Wlabs.Domain.Entities;

namespace Wlabs.Domain.Interfaces.Repository
{
    public interface ILocalizacaoAwesomeApiRepository
    {
        Task<LocalizacaoAwesomeApi> ObtemPorCep(string cep);
    }
}
