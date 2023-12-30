using Academia.GestionInventario.WebApi._Infrastructure.Entities.Empleados;
using Academia.GestionInventario.WebApi.Models.Empleados;
using Farsiman.Application.Core.Standard.DTOs;

namespace Academia.GestionInventario.WebApi.AppServices.Empleados
{
    public interface IEmpleadoAppService
    {
        Respuesta<List<ObtenerEmpleadoDto>> ObtenerEmpleados();
        Respuesta<AgregarEmpleadoDto> AgregarEmpleado(AgregarEmpleadoDto empleadoDto);
        Respuesta<ActualizarEmpleadoDto> ActualizarEmpleado(ActualizarEmpleadoDto empleadoDto);
        Respuesta<Empleado> CambiarEstadoEmpleado(int? empleadoId, int? usuarioId, bool estado);
    }
}
