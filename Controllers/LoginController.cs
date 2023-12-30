using Academia.GestionInventario.WebApi.AppServices.Login;
using Microsoft.AspNetCore.Mvc;

namespace Academia.GestionInventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginAppService _loginAppService;

        public LoginController(LoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }

        [HttpPost]
        [Route("IniciarSesion/{usuario}/{clave}")]
        public IActionResult Login(string usuario, string clave)
        {
            var user = _loginAppService.Login(usuario, clave);

            return Ok(user);
        }
    }
}
