using AutoMapper;
using FluentValidation.Results;
using MongoDB.Bson;
using NetDevPack.Mediator;
using Wlabs.Application.Interfaces;
using Wlabs.Application.ViewModels;
using Wlabs.Domain.Commands.Usuario;
using Wlabs.Domain.Interfaces.Repository;

namespace Wlabs.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediatorHandler _mediator;

        public UsuarioAppService(IMapper mapper,
                                  IUsuarioRepository usuarioRepository,
                                  IMediatorHandler mediator)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _mediator = mediator;
        }

        public Task<ValidationResult> Atualiza(UsuarioViewModel usuarioViewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationResult> Cadastra(CadastraUsuarioViewModel criaUsuarioViewModel)
        {
            var cadastraUsuarioCommand = _mapper.Map<CadastraUsuarioCommand>(criaUsuarioViewModel);
            return await _mediator.SendCommand(cadastraUsuarioCommand);
        }

        public async Task<UsuarioViewModel> ConsultaPorId(ObjectId id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObtemPorId(id));
        }

        public async Task<IEnumerable<UsuarioViewModel>> ConsultaTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObtemTodos());
        }

        public Task<ValidationResult> Remove(ObjectId id)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
