using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wlabs.Application.Interfaces;
using Wlabs.Services.Core.Controllers;

namespace Wlabs.Services.ViaCep.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class LocalizacaoController : ApiController
    {
        private readonly ILocalizacaoAppService _localizacaoAppService;

        public LocalizacaoController(ILocalizacaoAppService localizacaoAppService)
        {
            _localizacaoAppService = localizacaoAppService;
        }
        
        [HttpGet("{cep}")]
        public async Task<IActionResult> Get(string cep)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _localizacaoAppService.ConsultaViaCep(cep));
        }
    }
}
