using Academia.GestionInventario.WebApi.AppServices.Productos;
using Academia.GestionInventario.WebApi.Models.Productos;
using Microsoft.AspNetCore.Mvc;

namespace Academia.GestionInventario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoAppService _productoService;

        public ProductoController(ProductoAppService productoService)
        {
            _productoService = productoService;
        }

        [HttpPost]
        [Route("AgregarProducto")]
        public IActionResult AgregarProducto([FromBody] AgregarProductoDto productoDto)
        {
            var productos = _productoService.AgregarProducto(productoDto);
            return Ok(productos);
        }

        [HttpGet]
        [Route("ObtenerProductos")]
        public IActionResult ObtenerProductos()
        {
            var productos = _productoService.ObtenerProductos();
            return Ok(productos);
        }

        [HttpPut]
        [Route("ActualizarProducto")]
        public IActionResult ActualizarProducto([FromBody] ActualizarProductoDto productoDto)
        {
            var productos = _productoService.ActualizarProducto(productoDto);
            return Ok(productos);
        }

        [HttpPatch]
        [Route("CambiarEstadoProducto")]
        public IActionResult CambiarEstadoProducto(int productoId, int usuarioId, bool estado)
        {
            var productos = _productoService.CambiarEstadoProducto(productoId, usuarioId, estado);
            return Ok(productos);
        }
    }
}
