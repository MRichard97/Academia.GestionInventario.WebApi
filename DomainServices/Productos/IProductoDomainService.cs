using Academia.GestionInventario.WebApi.Models.Productos;

namespace Academia.GestionInventario.WebApi.DomainServices.Productos
{
    public interface IProductoDomainService
    {
        bool SePuedeAgregarProducto(AgregarProductoDto productoDto, out string mensaje);
        bool SePuedeActualizarProducto(ActualizarProductoDto productoDto, out string mensaje);
        bool SePuedeCambiarEstadoProducto(int? productoId, int? usuarioId, out string mensaje);
        bool ValidarNombreUnico(string nombre, string nombreDto, out string mensaje);
        bool ValidarEstadoProducto(bool estado, bool activo, out string mensaje);
    }
}
