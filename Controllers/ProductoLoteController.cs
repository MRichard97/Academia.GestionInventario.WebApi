using Academia.GestionInventario.WebApi.AppServices.ProductosLotes;
using Academia.GestionInventario.WebApi.Models.ProductosLotes;
using Microsoft.AspNetCore.Mvc;

namespace Academia.GestionInventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoLoteController : ControllerBase
    {
        private readonly ProductoLoteAppService _productoLoteService;

        public ProductoLoteController(ProductoLoteAppService productoLoteService)
        {
            _productoLoteService = productoLoteService;
        }

        [HttpPost]
        public IActionResult AgregarProductosLotes([FromBody] AgregarProductosLoteDto productoDto)
        {
            var lote = _productoLoteService.AgregarProductoLote(productoDto);
            return Ok(lote);
        }

        [HttpGet("{productoId}")]
        public IActionResult ObtenerLotes(int productoId)
        {
            var lote = _productoLoteService.ObtenerLotePorFechaVecimiento(productoId);
            return Ok(lote);
        }

        [HttpGet]
        public IActionResult ObtenerProductosLotes()
        {
            var lote = _productoLoteService.ObtenerProductosLotes();
            return Ok(lote);
        }

        [HttpPut]
        public IActionResult ActualizarProductoLote([FromBody] ActualizarProductosLotesDto productoDto)
        {
            var lote = _productoLoteService.ActualizarProductoLote(productoDto);
            return Ok(lote);
        }

        [HttpPatch]
        public IActionResult CambiarEstadoProductoLote(int productoId, int usuarioId, bool estado)
        {
            var lote = _productoLoteService.CambiarEstadoProductoLote(productoId, usuarioId, estado);
            return Ok(lote);
        }
    }
}
