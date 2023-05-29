using Microsoft.AspNetCore.Mvc;
using Wlabs.Application.Interfaces;
using Wlabs.Services.Core.Controllers;

namespace Wlabs.Services.ApiCep.Controllers
{
    //[Authorize]
    public class LocalizacaoController : ApiController
    {
        private readonly ILocalizacaoAppService _localizacaoAppService;

        public LocalizacaoController(ILocalizacaoAppService localizacaoAppService)
        {
            _localizacaoAppService = localizacaoAppService;
        }

        [HttpGet("localizacao/{cep}")]
        public async Task<IActionResult> GetFromApiCep(string cep)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _localizacaoAppService.ConsultaApiCep(cep));
        }
    }
}
