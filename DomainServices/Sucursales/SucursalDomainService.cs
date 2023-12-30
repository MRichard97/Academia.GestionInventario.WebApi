using Academia.GestionInventario.WebApi.Models.Sucursales;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;

namespace Academia.GestionInventario.WebApi.DomainServices.Sucursales
{
    public class SucursalDomainService : ISucursalDomainService
    {
        public bool SePuedeAgregarSucursal(AgregarSucursalDto sucursalDto, out string mensaje)
        {
            int limiteNombre = 50;
            if (string.IsNullOrEmpty(sucursalDto.Nombre))
            {
                mensaje = MensajesGlobales.Nombre_No_Ingresado;
                return false;
            }
            if (sucursalDto.Nombre.Length > limiteNombre)
            {
                mensaje = MensajesGlobales.Nombre_Muy_Extenso;
                return false;
            }
            if (!sucursalDto.UsuarioCreacionId.HasValue || sucursalDto.UsuarioCreacionId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (sucursalDto.FechaCreacion < DateTime.Now)
            {
                mensaje = MensajesGlobales.Fecha_No_Valida;
                return false;
            }
            if (!sucursalDto.FechaCreacion.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (!sucursalDto.Activo)
            {
                mensaje = MensajesGlobales.Sucursal_Inactiva_Agregada;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }
        public bool SePuedeActualizarSucursal(ActualizarSucursalDto sucursalDto, out string mensaje)
        {
            int limiteNombre = 50;
            if (string.IsNullOrEmpty(sucursalDto.Nombre))
            {
                mensaje = MensajesGlobales.Nombre_No_Ingresado;
                return false;
            }
            if (sucursalDto.Nombre.Length > limiteNombre)
            {
                mensaje = MensajesGlobales.Nombre_Muy_Extenso;
                return false;
            }
            if (!sucursalDto.UsuarioModificacionId.HasValue || sucursalDto.UsuarioModificacionId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (!sucursalDto.FechaModificacion.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (sucursalDto.FechaModificacion < DateTime.Now)
            {
                mensaje = MensajesGlobales.Fecha_No_Valida;
                return false;
            }
            if (!sucursalDto.SucursalId.HasValue || sucursalDto.SucursalId <= 0)
            {
                mensaje = MensajesGlobales.Sucursal_No_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }
        public bool SePuedeCambiarEstadoSucursal(int? sucursalId, int? usuarioId, out string mensaje)
        {
            if (!sucursalId.HasValue || sucursalId <= 0)
            {
                mensaje = MensajesGlobales.Sucursal_No_Existe;
                return false;
            }
            if (!usuarioId.HasValue || usuarioId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }
        public bool ValidarNombreUnico(string nombre, string nombreDto, out string mensaje)
        {
            if (nombre == nombreDto)
            {
                mensaje = MensajesGlobales.Nombre_Ya_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }
        public bool ValidarEstadoSucursal(bool estado, bool activo, out string mensaje)
        {
            if (estado == activo)
            {
                mensaje = MensajesGlobales.Estado_Igual;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }
    }
}
