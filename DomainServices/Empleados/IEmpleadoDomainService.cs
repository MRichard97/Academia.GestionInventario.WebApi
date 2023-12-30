using Academia.GestionInventario.WebApi.Models.Empleados;

namespace Academia.GestionInventario.WebApi.DomainServices.Empleados
{
    public interface IEmpleadoDomainService
    {
        bool SePuedeAgregarEmpleado(AgregarEmpleadoDto empleadoDto, out string mensaje);
        bool SePuedeActualizarEmpleado(ActualizarEmpleadoDto empleadoDto, out string mensaje);
        bool SePuedeCambiarEstadoEmpleado(int? EmpleadoId, int? usuarioId, out string mensaje);
        bool ValidarNombreUnico(string nombre, string apellido, string apellidoDto, string nombreDto, out string mensaje);
        bool ValidarEstadoEmpleado(bool estado, bool activo, out string mensaje);
    }
}
