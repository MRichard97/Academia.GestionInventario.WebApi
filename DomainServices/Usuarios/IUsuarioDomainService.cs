using Academia.GestionInventario.WebApi.Models.Usuarios;

namespace Academia.GestionInventario.WebApi.DomainServices.Usuarios
{
    public interface IUsuarioDomainService
    {
        bool SePuedeAgregarUsuario(AgregarUsuarioDto usuarioDto, out string mensaje);
        bool SePuedeActualizarUsuario(ActualizarUsuarioDto usuarioDto, out string mensaje);
        bool SePuedeCambiarEstadoUsuario(int? usuarioId, int? usuarioCambiaEstadoId, out string mensaje);
        bool ValidarUsuarioUnico(string usuario, string usuarioDto, out string mensaje);
        bool ValidarEstadoUsuario(bool estado, bool activo, out string mensaje);
    }
}
