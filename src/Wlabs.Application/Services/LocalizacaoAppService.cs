using AutoMapper;
using NetDevPack.Mediator;
using Serilog;
using Wlabs.Application.Interfaces;
using Wlabs.Application.ViewModels;
using Wlabs.Domain.Interfaces.Repository;

namespace Wlabs.Application.Services
{
    public class LocalizacaoAppService: ILocalizacaoAppService
    {
        private readonly IMapper _mapper;
        private readonly ILocalizacaoViaCepRepository _localizacaoViaCepRepository;
        private readonly ILocalizacaoApiCepRepository _localizacaoApiCepRepository;
        private readonly IMediatorHandler _mediator;

        public LocalizacaoAppService(IMapper mapper,
                                  ILocalizacaoViaCepRepository localizacaoViaCepRepository,
                                  ILocalizacaoApiCepRepository localizacaoApiCepRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _localizacaoViaCepRepository = localizacaoViaCepRepository;
            _localizacaoApiCepRepository = localizacaoApiCepRepository;
            _mediator = mediator;
        }

        public async Task<LocalizacaoApiCepViewModel> ConsultaApiCep(string cep)
        {
            Log.Information($"Executando o método {nameof(ConsultaApiCep)} na classe: {GetType().Name}");

            return _mapper.Map<LocalizacaoApiCepViewModel>(await _localizacaoApiCepRepository.ObtemPorCep(cep));
        }

        public async Task<LocalizacaoViaCepViewModel> ConsultaViaCep(string cep)
        {
            Log.Information($"Executando o método {nameof(ConsultaViaCep)} na classe: {GetType().Name}");

            return _mapper.Map<LocalizacaoViaCepViewModel>(await _localizacaoViaCepRepository.ObtemPorCep(cep));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
