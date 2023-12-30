using Academia.GestionInventario.WebApi.Models.Productos;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;

namespace Academia.GestionInventario.WebApi.DomainServices.Productos
{
    public class ProductoDomainService : IProductoDomainService
    {
        public bool SePuedeActualizarProducto(ActualizarProductoDto productoDto, out string mensaje)
        {
            int limiteNombre = 50;
            if (string.IsNullOrEmpty(productoDto.Nombre))
            {
                mensaje = MensajesGlobales.Nombre_No_Ingresado;
                return false;
            }
            if (productoDto.Nombre.Length > limiteNombre)
            {
                mensaje = MensajesGlobales.Nombre_Muy_Extenso;
                return false;
            }
            if (!productoDto.UsuarioModificacionId.HasValue || productoDto.UsuarioModificacionId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (!productoDto.FechaModificacion.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (productoDto.FechaModificacion < DateTime.Now)
            {
                mensaje = MensajesGlobales.Fecha_No_Valida;
                return false;
            }
            if (!productoDto.ProductoId.HasValue || productoDto.ProductoId <= 0)
            {
                mensaje = MensajesGlobales.Producto_No_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool SePuedeAgregarProducto(AgregarProductoDto productoDto, out string mensaje)
        {
            int limiteNombre = 50;
            if (string.IsNullOrEmpty(productoDto.Nombre))
            {
                mensaje = MensajesGlobales.Nombre_No_Ingresado;
                return false;
            }
            if (productoDto.Nombre.Length > limiteNombre)
            {
                mensaje = MensajesGlobales.Nombre_Muy_Extenso;
                return false;
            }
            if (!productoDto.UsuarioCreacionId.HasValue || productoDto.UsuarioCreacionId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (productoDto.FechaCreacion < DateTime.Now)
            {
                mensaje = MensajesGlobales.Fecha_No_Valida;
                return false;
            }
            if (!productoDto.FechaCreacion.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (!productoDto.Activo)
            {
                mensaje = MensajesGlobales.Producto_Inactivo_Agregado;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool SePuedeCambiarEstadoProducto(int? productoId, int? usuarioId, out string mensaje)
        {
            if (!productoId.HasValue || productoId <= 0)
            {
                mensaje = MensajesGlobales.Producto_No_Existe;
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

        public bool ValidarEstadoProducto(bool estado, bool activo, out string mensaje)
        {
            if (estado == activo)
            {
                mensaje = MensajesGlobales.Estado_Igual;
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
    }
}
