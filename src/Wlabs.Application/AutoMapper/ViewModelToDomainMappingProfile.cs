using AutoMapper;
using Wlabs.Application.ViewModels;
using Wlabs.Domain.Commands.Usuario;

namespace Wlabs.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {            
            CreateMap<CadastraUsuarioViewModel, CadastraUsuarioCommand>()
                .ConstructUsing(c => new CadastraUsuarioCommand(c.Nome, c.Email, c.Senha));
        }
    }
}
