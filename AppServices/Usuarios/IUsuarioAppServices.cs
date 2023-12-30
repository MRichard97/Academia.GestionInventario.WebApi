using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;
using Academia.GestionInventario.WebApi.Models.Usuarios;
using Farsiman.Application.Core.Standard.DTOs;

namespace Academia.GestionInventario.WebApi.AppServices.Usuarios
{
    public interface IUsuarioAppServices
    {
        Respuesta<List<ObtenerUsuarioDto>> ObtenerUsuarios();
        Respuesta<AgregarUsuarioDto> AgregarUsuarios(AgregarUsuarioDto usuarioDto);
        Respuesta<ActualizarUsuarioDto> ActualizarUsuario(ActualizarUsuarioDto usuarioDto);
        Respuesta<Usuario> CambiarEstadoUsuario(int? usuarioId, int? usuarioActualizaId, bool estado);
    }
}
