using Microsoft.AspNetCore.Mvc;
using Wlabs.Application.Interfaces;
using Wlabs.Application.ViewModels;
using Wlabs.Services.Core.Controllers;

namespace Wlabs.Services.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public LoginController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(LoginViewModel loginViewModel)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.EfetuaLogin(loginViewModel));
        }
    }
}