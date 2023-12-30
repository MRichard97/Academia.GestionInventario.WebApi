using Academia.GestionInventario.WebApi._Infrastructure.Entities.Productos;
using Academia.GestionInventario.WebApi.Models.Productos;
using Farsiman.Application.Core.Standard.DTOs;

namespace Academia.GestionInventario.WebApi.AppServices.Productos
{
    public interface IProductoAppService
    {
        Respuesta<List<ObtenerProductoDto>> ObtenerProductos();
        Respuesta<AgregarProductoDto> AgregarProducto(AgregarProductoDto productoDto);
        Respuesta<ActualizarProductoDto> ActualizarProducto(ActualizarProductoDto productoDto);
        Respuesta<Producto> CambiarEstadoProducto(int productoId, int usuarioId, bool estado);

    }
}
