using Academia.GestionInventario.WebApi.Models.ProductosLotes;

namespace Academia.GestionInventario.WebApi.DomainServices.ProductosLotes
{
    public interface IProductoLoteDomainService
    {
        bool SePuedeAgregarLote(AgregarProductosLoteDto loteDto, out string mensaje);
        bool SePuedeActualizarLote(ActualizarProductosLotesDto loteDto, out string mensaje);
        bool SePuedeCambiarEstadoLote(int? loteId, int? usuarioId, out string mensaje);
        bool ValidarEstadoLote(bool estado, bool activo, out string mensaje);
    }
}
