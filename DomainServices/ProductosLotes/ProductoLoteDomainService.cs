using Academia.GestionInventario.WebApi.Models.ProductosLotes;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;

namespace Academia.GestionInventario.WebApi.DomainServices.ProductosLotes
{
    public class ProductoLoteDomainService : IProductoLoteDomainService
    {
        public bool SePuedeActualizarLote(ActualizarProductosLotesDto loteDto, out string mensaje)
        {
            if (loteDto.CantidadInicial <= 0)
            {
                mensaje = MensajesGlobales.Cantidad_No_Valido;
                return false;
            }
            if (!loteDto.CantidadInicial.HasValue)
            {
                mensaje = MensajesGlobales.Cantidad_No_Ingresado;
                return false;
            }
            if (loteDto.Costo <= 0)
            {
                mensaje = MensajesGlobales.Costo_No_Valido;
                return false;
            }
            if (!loteDto.Costo.HasValue)
            {
                mensaje = MensajesGlobales.Costo_No_Ingresado;
                return false;
            }
            if (loteDto.Costo <= 0)
            {
                mensaje = MensajesGlobales.Costo_No_Valido;
                return false;
            }
            if (!loteDto.Costo.HasValue)
            {
                mensaje = MensajesGlobales.Costo_No_Ingresado;
                return false;
            }
            if (loteDto.Inventario <= 0)
            {
                mensaje = MensajesGlobales.Inventario_No_Valido;
                return false;
            }
            if (!loteDto.Inventario.HasValue)
            {
                mensaje = MensajesGlobales.Inventario_No_Ingresado;
                return false;
            }
            if (!loteDto.FechaVencimiento.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (!loteDto.UsuarioModificacionId.HasValue || loteDto.UsuarioModificacionId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (!loteDto.FechaModificacion.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (!loteDto.ProductoId.HasValue || loteDto.ProductoId <= 0)
            {
                mensaje = MensajesGlobales.Producto_No_Existe;
                return false;
            }
            if (!loteDto.LoteId.HasValue || loteDto.LoteId <= 0)
            {
                mensaje = MensajesGlobales.Lote_No_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool SePuedeAgregarLote(AgregarProductosLoteDto loteDto, out string mensaje)
        {
            if (loteDto.CantidadInicial <= 0)
            {
                mensaje = MensajesGlobales.Cantidad_No_Valido;
                return false;
            }
            if (!loteDto.CantidadInicial.HasValue)
            {
                mensaje = MensajesGlobales.Cantidad_No_Ingresado;
                return false;
            }
            if (loteDto.Costo <= 0)
            {
                mensaje = MensajesGlobales.Costo_No_Valido;
                return false;
            }
            if (!loteDto.Costo.HasValue)
            {
                mensaje = MensajesGlobales.Costo_No_Ingresado;
                return false;
            }
            if (loteDto.Costo <= 0)
            {
                mensaje = MensajesGlobales.Costo_No_Valido;
                return false;
            }
            if (!loteDto.Costo.HasValue)
            {
                mensaje = MensajesGlobales.Costo_No_Ingresado;
                return false;
            }
            if (loteDto.Inventario <= 0)
            {
                mensaje = MensajesGlobales.Inventario_No_Valido;
                return false;
            }
            if (!loteDto.Inventario.HasValue)
            {
                mensaje = MensajesGlobales.Inventario_No_Ingresado;
                return false;
            }
            if (!loteDto.FechaVencimiento.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (!loteDto.UsuarioCreacionId.HasValue || loteDto.UsuarioCreacionId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            if (!loteDto.FechaCreacion.HasValue)
            {
                mensaje = MensajesGlobales.Fecha_No_Ingresada;
                return false;
            }
            if (loteDto.FechaCreacion < DateTime.Now)
            {
                mensaje = MensajesGlobales.Fecha_No_Valida;
                return false;
            }
            if (!loteDto.ProductoId.HasValue || loteDto.ProductoId <= 0)
            {
                mensaje = MensajesGlobales.Producto_No_Existe;
                return false;
            }
            if (!loteDto.Activo)
            {
                mensaje = MensajesGlobales.Lote_Inactivo_Agregado;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool SePuedeCambiarEstadoLote(int? loteId, int? usuarioId, out string mensaje)
        {
            if (!loteId.HasValue || loteId <= 0)
            {
                mensaje = MensajesGlobales.Lote_No_Existe;
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

        public bool ValidarEstadoLote(bool estado, bool activo, out string mensaje)
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
