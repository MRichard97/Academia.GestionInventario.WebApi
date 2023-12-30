using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventarios;
using Academia.GestionInventario.WebApi.Models.SalidasInventarios;
using Farsiman.Application.Core.Standard.DTOs;

namespace Academia.GestionInventario.WebApi.AppServices.SalidasInventarios
{
    public interface ISalidaInventarioAppService
    {
        Respuesta<SalidaInventarioDto> AgregarSalidaInventario(AgregarSalidaInventarioDto inventarioDto);
        Respuesta<List<ObtenerSalidaInventarioDto>> ReporteSalidas(DateTime fechaInicio, DateTime fechaFinal, int sucursalId);
        Respuesta<ObtenerSalidaInventarioDto> ObtenerSalida(int salididaId);
        Respuesta<SalidasInventario> RecepcionSalida(int salididaId, int usuarioRecepcionId);
    }
}
