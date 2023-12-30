using Academia.GestionInventario.WebApi.Models.Empleados;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;

namespace Academia.GestionInventario.WebApi.DomainServices.Empleados
{
    public class EmpleadoDomainService : IEmpleadoDomainService
    {
        public bool SePuedeActualizarEmpleado(ActualizarEmpleadoDto empleadoDto, out string mensaje)
        {
            int limiteNombre = 150;
            int limiteDireccion = 200;
            if (string.IsNullOrEmpty(empleadoDto.Nombre) || string.IsNullOrEmpty(empleadoDto.Apellido))
            {
                mensaje = MensajesGlobales.Nombre_No_Ingresado;
                return false;
            }
            if (empleadoDto.Nombre.Length > limiteNombre || empleadoDto.Apellido.Length > limiteNombre)
            {
                mensaje = MensajesGlobales.Nombre_Muy_Extenso;
                return false;
            }
            if (string.IsNullOrEmpty(empleadoDto.Direccion))
            {
                mensaje = MensajesGlobales.Direccion_No_Ingresa;
                return false;
            }
            if (empleadoDto.Direccion.Length > limiteDireccion)
            {
                mensaje = MensajesGlobales.Direccion_Muy_Extensa;
                return false;
            }
            if (!empleadoDto.UsuarioModificacionId.HasValue || empleadoDto.UsuarioModificacionId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (!empleadoDto.FechaModificacion.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (empleadoDto.FechaModificacion < DateTime.Now)
            {
                mensaje = MensajesGlobales.Fecha_No_Valida;
                return false;
            }
            if (!empleadoDto.EmpleadoId.HasValue || empleadoDto.EmpleadoId <= 0)
            {
                mensaje = MensajesGlobales.Sucursal_No_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool SePuedeAgregarEmpleado(AgregarEmpleadoDto empleadoDto, out string mensaje)
        {
            int limiteNombre = 150;
            int limiteDireccion = 200;
            if (string.IsNullOrEmpty(empleadoDto.Nombre) || string.IsNullOrEmpty(empleadoDto.Apellido))
            {
                mensaje = MensajesGlobales.Nombre_No_Ingresado;
                return false;
            }
            if (empleadoDto.Nombre.Length > limiteNombre || empleadoDto.Apellido.Length > limiteNombre)
            {
                mensaje = MensajesGlobales.Nombre_Muy_Extenso;
                return false;
            }
            if (string.IsNullOrEmpty(empleadoDto.Direccion))
            {
                mensaje = MensajesGlobales.Direccion_No_Ingresa;
                return false;
            }
            if (empleadoDto.Direccion.Length > limiteDireccion)
            {
                mensaje = MensajesGlobales.Direccion_Muy_Extensa;
                return false;
            }
            if (!empleadoDto.UsuarioCreacionId.HasValue || empleadoDto.UsuarioCreacionId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (empleadoDto.FechaCreacion < DateTime.Now)
            {
                mensaje = MensajesGlobales.Fecha_No_Valida;
                return false;
            }
            if (!empleadoDto.FechaCreacion.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (!empleadoDto.Activo)
            {
                mensaje = MensajesGlobales.Empleado_Inactivo_Agregado;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool SePuedeCambiarEstadoEmpleado(int? EmpleadoId, int? usuarioId, out string mensaje)
        {
            if (!EmpleadoId.HasValue || EmpleadoId <= 0)
            {
                mensaje = MensajesGlobales.Empleado_No_Existe;
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

        public bool ValidarEstadoEmpleado(bool estado, bool activo, out string mensaje)
        {
            if (estado == activo)
            {
                mensaje = MensajesGlobales.Estado_Igual;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool ValidarNombreUnico(string nombre, string apellido, string apellidoDto, string nombreDto, out string mensaje)
        {
            if (nombre == nombreDto || apellido == apellidoDto)
            {
                mensaje = MensajesGlobales.Nombre_Ya_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }
    }
}
