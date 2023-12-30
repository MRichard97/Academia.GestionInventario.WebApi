using Academia.GestionInventario.WebApi.AppServices.Sucursales;
using Academia.GestionInventario.WebApi.Models.Sucursales;
using Microsoft.AspNetCore.Mvc;

namespace Academia.GestionInventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalController : ControllerBase
    {
        private readonly SucursalAppServices _sucursalService;

        public SucursalController(SucursalAppServices sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpPost]
        [Route("AgregarSucursal")]
        public IActionResult AgregarSucursal([FromBody] AgregarSucursalDto sucursalDto)
        {
            var sucursales = _sucursalService.AgregarSucursal(sucursalDto);
            return Ok(sucursales);
        }

        [HttpGet]
        [Route("ObtenerSucursales")]
        public IActionResult ObtenerSucursales()
        {
            var sucursales = _sucursalService.ObtenerSucursales();
            return Ok(sucursales);
        }

        [HttpPut]
        [Route("ActualizarSucursal")]
        public IActionResult ActualizarSucursal([FromBody] ActualizarSucursalDto sucursalDto)
        {
            var sucursales = _sucursalService.ActualizarSucursal(sucursalDto);
            return Ok(sucursales);
        }

        [HttpPatch]
        [Route("CambiarEstadoSucursal")]
        public IActionResult CambiarEstadoSucursal(int sucursalId, int usuarioId, bool estado)
        {
            var sucursales = _sucursalService.CambiarEstadoSucursal(sucursalId, usuarioId, estado);
            return Ok(sucursales);
        }
    }
}
