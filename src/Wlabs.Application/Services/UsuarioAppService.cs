using AutoMapper;
using FluentValidation.Results;
using MongoDB.Bson;
using NetDevPack.Mediator;
using Serilog;
using Wlabs.Application.Interfaces;
using Wlabs.Application.ViewModels;
using Wlabs.Domain.Commands.Usuario;
using Wlabs.Domain.Interfaces.Repository;
using Wlabs.Infra.CrossCutting.Jwt.Interfaces;

namespace Wlabs.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IJwtUtils _jwtUtils;


        public UsuarioAppService(IMapper mapper,
                                  IUsuarioRepository usuarioRepository,
                                  IMediatorHandler mediator,
                                  IJwtUtils jwtUtils)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _mediator = mediator;
            _jwtUtils = jwtUtils;
        }

        public Task<ValidationResult> Atualiza(UsuarioViewModel usuarioViewModel)
        {
            Log.Information($"Executando o método {nameof(Atualiza)} na classe: {GetType().Name}");

            throw new NotImplementedException();
        }

        public async Task<ValidationResult> Cadastra(CadastraUsuarioViewModel criaUsuarioViewModel)
        {
            Log.Information($"Executando o método {nameof(Cadastra)} na classe: {GetType().Name}");

            var cadastraUsuarioCommand = _mapper.Map<CadastraUsuarioCommand>(criaUsuarioViewModel);
            return await _mediator.SendCommand(cadastraUsuarioCommand);
        }

        public async Task<UsuarioViewModel> ConsultaPorId(ObjectId id)
        {
            Log.Information($"Executando o método {nameof(ConsultaPorId)} na classe: {GetType().Name}");

            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObtemPorId(id));
        }

        public async Task<IEnumerable<UsuarioViewModel>> ConsultaTodos()
        {
            Log.Information($"Executando o método {nameof(ConsultaTodos)} na classe: {GetType().Name}");

            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObtemTodos());
        }

        public Task<ValidationResult> Remove(ObjectId id)
        {
            Log.Information($"Executando o método {nameof(Remove)} na classe: {GetType().Name}");

            throw new NotImplementedException();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<JwtResponseViewModel> EfetuaLogin(LoginViewModel loginViewModel)
        {
            Log.Information($"Executando o método {nameof(EfetuaLogin)} na classe: {GetType().Name}");

            var usuario = await _usuarioRepository.ObtemPorEmailESenha(loginViewModel.Email, loginViewModel.Senha);
            if (usuario == null) return null;
            var token = _jwtUtils.GenerateJwtToken(usuario);
            return _mapper.Map<JwtResponseViewModel>(token);
        }
    }
}
