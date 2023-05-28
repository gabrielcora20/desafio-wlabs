using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Wlabs.Application.Interfaces;
using Wlabs.Application.ViewModels;

namespace Wlabs.Services.Api.Controllers
{
    //[Authorize]
    public class LocalizacaoController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public LocalizacaoController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        //[HttpGet("usuario-management")]
        //public async Task<IEnumerable<UsuarioViewModel>> Get()
        //{
        //    return await _usuarioAppService.GetAll();
        //}

        [HttpGet("usuario/{id}")]
        public async Task<UsuarioViewModel> Get(ObjectId id)
        {
            return await _usuarioAppService.ConsultaPorId(id);
        }

        [HttpPost("usuario")]
        public async Task<IActionResult> Post([FromBody] CadastraUsuarioViewModel usuarioViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.Cadastra(usuarioViewModel));
        }

        //[HttpPut("usuario-management")]
        //public async Task<IActionResult> Put([FromBody]UsuarioViewModel usuarioViewModel)
        //{
        //    return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.Update(usuarioViewModel));
        //}

        //[HttpDelete("usuario-management")]
        //public async Task<IActionResult> Delete(ObjectId id)
        //{
        //    return CustomResponse(await _usuarioAppService.Remove(id));
        //}
    }
}
