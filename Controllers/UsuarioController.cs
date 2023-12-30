using Academia.GestionInventario.WebApi.AppServices.Usuarios;
using Academia.GestionInventario.WebApi.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;

namespace Academia.GestionInventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioAppService _usuarioService;

        public UsuarioController(UsuarioAppService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost]
        public IActionResult AgregarUsuarios([FromBody] AgregarUsuarioDto usuarioDto)
        {
            var usuarios = _usuarioService.AgregarUsuarios(usuarioDto);
            return Ok(usuarios);
        }

        [HttpGet]
        public IActionResult ObtenerUsuarios()
        {
            var usuarios = _usuarioService.ObtenerUsuarios();
            return Ok(usuarios);
        }

        [HttpPut]
        public IActionResult ActualizarUsuario([FromBody] ActualizarUsuarioDto usuarioDto)
        {
            var usuarios = _usuarioService.ActualizarUsuario(usuarioDto);
            return Ok(usuarios);
        }

        [HttpPatch]
        public IActionResult CambiarEstadoUsuario(int usuarioId, int usuarioCambiaEstadoId, bool estado)
        {
            var usuarios = _usuarioService.CambiarEstadoUsuario(usuarioId, usuarioCambiaEstadoId, estado);
            return Ok(usuarios);
        }
    }
}
