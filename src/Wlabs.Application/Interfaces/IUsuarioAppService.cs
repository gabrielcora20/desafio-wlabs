using Wlabs.Application.ViewModels;
using FluentValidation.Results;

namespace Wlabs.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        Task<IEnumerable<UsuarioViewModel>> ConsultaTodos();
        Task<UsuarioViewModel> ConsultaPorId(string id);        
        Task<ValidationResult> Cadastra(UsuarioViewModel usuarioViewModel);
        Task<ValidationResult> Atualiza(UsuarioViewModel usuarioViewModel);
        Task<ValidationResult> Remove(string id);
    }
}
