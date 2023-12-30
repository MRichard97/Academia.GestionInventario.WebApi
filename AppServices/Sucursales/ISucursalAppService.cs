using Academia.GestionInventario.WebApi._Infrastructure.Entities.Sucursales;
using Academia.GestionInventario.WebApi.Models.Sucursales;
using Farsiman.Application.Core.Standard.DTOs;

namespace Academia.GestionInventario.WebApi.AppServices.Sucursales
{
    public interface ISucursalAppService
    {
        Respuesta<List<ObtenerSucursalDto>> ObtenerSucursales();
        Respuesta<AgregarSucursalDto> AgregarSucursal(AgregarSucursalDto sucursalDto);
        Respuesta<ActualizarSucursalDto> ActualizarSucursal(ActualizarSucursalDto sucursalDto);
        Respuesta<Sucursal> CambiarEstadoSucursal(int? sucursalId, int? usuarioId, bool estado);
    }
}
