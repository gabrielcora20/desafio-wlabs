using Wlabs.Application.ViewModels;
using FluentValidation.Results;
using MongoDB.Bson;

namespace Wlabs.Application.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        Task<IEnumerable<UsuarioViewModel>> ConsultaTodos();
        Task<UsuarioViewModel> ConsultaPorId(ObjectId id);        
        Task<ValidationResult> Cadastra(CadastraUsuarioViewModel criaUsuarioViewModel);
        Task<ValidationResult> Atualiza(UsuarioViewModel usuarioViewModel);
        Task<ValidationResult> Remove(ObjectId id);
    }
}
