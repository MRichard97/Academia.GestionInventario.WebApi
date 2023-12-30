using Academia.GestionInventario.WebApi.Models.Usuarios;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;

namespace Academia.GestionInventario.WebApi.DomainServices.Usuarios
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        public bool SePuedeActualizarUsuario(ActualizarUsuarioDto usuarioDto, out string mensaje)
        {
            int limiteCaracteres = 50;
            if (string.IsNullOrEmpty(usuarioDto.Nombre))
            {
                mensaje = MensajesGlobales.Nombre_No_Ingresado;
                return false;
            }
            if (usuarioDto.Nombre.Length > limiteCaracteres)
            {
                mensaje = MensajesGlobales.Nombre_Muy_Extenso;
                return false;
            }
            if (string.IsNullOrEmpty(usuarioDto.Clave))
            {
                mensaje = MensajesGlobales.Clave_No_Ingresada;
                return false;
            }
            if (usuarioDto.Clave.Length > limiteCaracteres)
            {
                mensaje = MensajesGlobales.Clave_Muy_Extensa;
                return false;
            }
            if (!usuarioDto.UsuarioModificacionId.HasValue || usuarioDto.UsuarioModificacionId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (!usuarioDto.FechaModificacion.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (!usuarioDto.EmpleadoId.HasValue || usuarioDto.EmpleadoId <= 0)
            {
                mensaje = MensajesGlobales.Empleado_No_Existe;
                return false;
            }
            if (!usuarioDto.PerfilId.HasValue || usuarioDto.PerfilId <= 0)
            {
                mensaje = MensajesGlobales.Perfil_No_Existe;
                return false;
            }
            if (!usuarioDto.UsuarioId.HasValue || usuarioDto.UsuarioId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool SePuedeAgregarUsuario(AgregarUsuarioDto usuarioDto, out string mensaje)
        {
            int limiteCaracteres = 50;
            if (string.IsNullOrEmpty(usuarioDto.Nombre))
            {
                mensaje = MensajesGlobales.Nombre_No_Ingresado;
                return false;
            }
            if (usuarioDto.Nombre.Length > limiteCaracteres)
            {
                mensaje = MensajesGlobales.Nombre_Muy_Extenso;
                return false;
            }
            if (string.IsNullOrEmpty(usuarioDto.Clave))
            {
                mensaje = MensajesGlobales.Clave_No_Ingresada;
                return false;
            }
            if (usuarioDto.Clave.Length > limiteCaracteres)
            {
                mensaje = MensajesGlobales.Clave_Muy_Extensa;
                return false;
            }
            if (!usuarioDto.UsuarioCreacionId.HasValue || usuarioDto.UsuarioCreacionId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (!usuarioDto.FechaCreacion.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (usuarioDto.FechaCreacion < DateTime.Now)
            {
                mensaje = MensajesGlobales.Fecha_No_Valida;
                return false;
            }
            if (!usuarioDto.EmpleadoId.HasValue || usuarioDto.EmpleadoId <= 0)
            {
                mensaje = MensajesGlobales.Empleado_No_Existe;
                return false;
            }
            if (!usuarioDto.PerfilId.HasValue || usuarioDto.PerfilId <= 0)
            {
                mensaje = MensajesGlobales.Perfil_No_Existe;
                return false;
            }
            if (!usuarioDto.Activo)
            {
                mensaje = MensajesGlobales.Usuario_Inactivo_Agregado;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool SePuedeCambiarEstadoUsuario(int? usuarioId, int? usuarioCambiaEstadoId, out string mensaje)
        {
            if (!usuarioId.HasValue || usuarioId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (!usuarioCambiaEstadoId.HasValue || usuarioCambiaEstadoId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool ValidarEstadoUsuario(bool estado, bool activo, out string mensaje)
        {
            if (estado == activo)
            {
                mensaje = MensajesGlobales.Estado_Igual;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool ValidarUsuarioUnico(string usuario, string usuarioDto, out string mensaje)
        {
            if (usuario == usuarioDto)
            {
                mensaje = MensajesGlobales.Usuario_Ya_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }
    }
}
