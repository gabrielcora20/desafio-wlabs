using AutoMapper;
using Wlabs.Application.ViewModels;
using Wlabs.Domain.Entities;

namespace Wlabs.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
            CreateMap<LocalizacaoViaCep, LocalizacaoViaCepViewModel>();
            CreateMap<LocalizacaoApiCep, LocalizacaoApiCepViewModel>();
            CreateMap<LocalizacaoAwesomeApi, LocalizacaoAwesomeApiViewModel>();
            CreateMap<string, JwtResponseViewModel>()
                .ConstructUsing(t => new JwtResponseViewModel() { Token = t });
        }
    }
}
