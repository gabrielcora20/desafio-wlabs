using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Wlabs.Services.Api.Controllers
{
    [Authorize]
    public class LocalizacaoController : ApiController
    {
        //private readonly IUsuarioAppService _usuarioAppService;

        //public LocalizacaoController(IUsuarioAppService usuarioAppService)
        //{
        //    _usuarioAppService = usuarioAppService;
        //}

        //[HttpGet("usuario-management")]
        //public async Task<IEnumerable<UsuarioViewModel>> Get()
        //{
        //    return await _usuarioAppService.GetAll();
        //}

        //[HttpGet("usuario-management/{id:guid}")]
        //public async Task<UsuarioViewModel> Get(Guid id)
        //{
        //    return await _usuarioAppService.GetById(id);
        //}

        //[HttpPost("usuario-management")]
        //public async Task<IActionResult> Post([FromBody]UsuarioViewModel usuarioViewModel)
        //{
        //    return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.Register(usuarioViewModel));
        //}

        //[HttpPut("usuario-management")]
        //public async Task<IActionResult> Put([FromBody]UsuarioViewModel usuarioViewModel)
        //{
        //    return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.Update(usuarioViewModel));
        //}

        //[HttpDelete("usuario-management")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    return CustomResponse(await _usuarioAppService.Remove(id));
        //}
    }
}
