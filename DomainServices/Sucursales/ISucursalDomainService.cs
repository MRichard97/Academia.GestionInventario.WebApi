using Academia.GestionInventario.WebApi.Models.Sucursales;

namespace Academia.GestionInventario.WebApi.DomainServices.Sucursales
{
    public interface ISucursalDomainService
    {
        bool SePuedeAgregarSucursal(AgregarSucursalDto sucursalDto, out string mensaje);
        bool SePuedeActualizarSucursal(ActualizarSucursalDto sucursalDto, out string mensaje);
        bool SePuedeCambiarEstadoSucursal(int? sucursalId, int? usuarioId, out string mensaje);
        bool ValidarNombreUnico(string nombre, string nombreDto, out string mensaje);
        bool ValidarEstadoSucursal(bool estado, bool activo, out string mensaje);
    }
}
