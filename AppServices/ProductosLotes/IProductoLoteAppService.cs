using Academia.GestionInventario.WebApi._Infrastructure.Entities.ProductosLotes;
using Academia.GestionInventario.WebApi.Models.ProductosLotes;
using Farsiman.Application.Core.Standard.DTOs;

namespace Academia.GestionInventario.WebApi.AppServices.ProductosLotes
{
    public interface IProductoLoteAppService
    {
        Respuesta<List<ObtenerProductoLoteDto>> ObtenerProductosLotes();
        Respuesta<ObtenerProductoLoteDto> ObtenerLotePorFechaVecimiento(int productoId);
        Respuesta<AgregarProductosLoteDto> AgregarProductoLote(AgregarProductosLoteDto productoDto);
        Respuesta<ActualizarProductosLotesDto> ActualizarProductoLote(ActualizarProductosLotesDto productoDto);
        Respuesta<ProductosLote> CambiarEstadoProductoLote(int? productoLoteId, int? usuarioId, bool estado);
    }
}
