using Microsoft.AspNetCore.Mvc;
using Wlabs.Application.Interfaces;

namespace Wlabs.Services.ViaCep.Controllers
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
        public async Task<IActionResult> GetFromViaCep(string cep)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _localizacaoAppService.ConsultaViaCep(cep));
        }
    }
}
