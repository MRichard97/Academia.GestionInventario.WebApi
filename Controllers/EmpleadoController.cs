using Academia.GestionInventario.WebApi.AppServices.Empleados;
using Academia.GestionInventario.WebApi.Models.Empleados;
using Microsoft.AspNetCore.Mvc;

namespace Academia.GestionInventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly EmpleadoAppService _empleadoService;

        public EmpleadoController(EmpleadoAppService empleadoService)
        {
            _empleadoService = empleadoService;
        }


        [HttpPost]
        public IActionResult AgregarEmpleado([FromBody] AgregarEmpleadoDto empleadoDto)
        {
            var empelados = _empleadoService.AgregarEmpleado(empleadoDto);
            return Ok(empelados);
        }

        [HttpGet]
        public IActionResult ObtenerEmpleados()
        {
            var empelados = _empleadoService.ObtenerEmpleados();
            return Ok(empelados);
        }

        [HttpPut]
        public IActionResult ActualizarEmpleado([FromBody] ActualizarEmpleadoDto empleadoDto)
        {
            var empelados = _empleadoService.ActualizarEmpleado(empleadoDto);
            return Ok(empleadoDto);
        }

        [HttpPatch]
        public IActionResult CambiarEstadoEmpleado(int empleadoId, int usuarioId, bool estado)
        {
            var empelados = _empleadoService.CambiarEstadoEmpleado(empleadoId, usuarioId, estado);
            return Ok(empelados);
        }
    }
}
