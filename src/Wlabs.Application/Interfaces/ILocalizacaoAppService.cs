using Wlabs.Application.ViewModels;

namespace Wlabs.Application.Interfaces
{
    public interface ILocalizacaoAppService : IDisposable
    {
        Task<LocalizacaoViaCepViewModel> ConsultaViaCep(string cep);
        Task<LocalizacaoApiCepViewModel> ConsultaApiCep(string cep);
        Task<LocalizacaoAwesomeApiViewModel> ConsultaAwesomeApi(string cep);
    }
}
