using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Wlabs.Application.Interfaces;
using Wlabs.Application.ViewModels;
using Wlabs.Services.Core.Controllers;

namespace Wlabs.Services.Usuario.Controllers
{
    [Route("[controller]")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CadastraUsuarioViewModel cadastraUsuarioView)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.Cadastra(cadastraUsuarioView));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.ConsultaTodos());
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(ObjectId id)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.ConsultaPorId(id));
        }
    }
}
