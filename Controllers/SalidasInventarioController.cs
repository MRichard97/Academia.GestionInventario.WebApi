using Academia.GestionInventario.WebApi.AppServices.SalidasInventarios;
using Academia.GestionInventario.WebApi.Models.SalidasInventarios;
using Microsoft.AspNetCore.Mvc;

namespace Academia.GestionInventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalidasInventarioController : ControllerBase
    {
        private readonly SalidaInventrioAppService _salidaInventrioService;
        public SalidasInventarioController(SalidaInventrioAppService salidaInventrioService)
        {
            _salidaInventrioService = salidaInventrioService;
        }

        [HttpPost]
        public IActionResult AgregarSalidaInventario([FromBody] AgregarSalidaInventarioDto inventarioDto)
        {
            var salidas = _salidaInventrioService.AgregarSalidaInventario(inventarioDto);
            return Ok(salidas);
        }
        [HttpGet("{fechaInicio}/{fechaFinal}/{sucursalId}")]
        public IActionResult ReporteSalidas(DateTime fechaInicio, DateTime fechaFinal, int sucursalId)
        {
            var salidas = _salidaInventrioService.ReporteSalidas(fechaInicio, fechaFinal, sucursalId);
            return Ok(salidas);
        }

        [HttpGet("{salidaId}")]
        public IActionResult ObtenerSalida(int salidaId)
        {
            var salidas = _salidaInventrioService.ObtenerSalida(salidaId);
            return Ok(salidas);
        }

        [HttpPut("{salidaId}/{usuarioRecepcionId}")]
        public IActionResult Recepcion(int salidaId, int usuarioRecepcionId)
        {
            var salidas = _salidaInventrioService.RecepcionSalida(salidaId, usuarioRecepcionId);
            return Ok(salidas);
        }
    }
}
