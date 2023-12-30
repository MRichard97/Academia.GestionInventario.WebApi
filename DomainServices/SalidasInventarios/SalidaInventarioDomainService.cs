using Academia.GestionInventario.WebApi._Common.Enums;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventarios;
using ContabilidadValesCajaChicaApi._Commons.MensajesGlobales;

namespace Academia.GestionInventario.WebApi.DomainServices.SalidasInventarios
{
    public class SalidaInventarioDomainService
    {
        public bool ValidarSalidaInventario(decimal? costoTotal, int sucursalId, int usuarioId, out string mensaje)
        {
            if (costoTotal <= 0)
            {
                mensaje = MensajesGlobales.Costo_Total_No_Valido;
                return false;
            }
            if (sucursalId <= 0)
            {
                mensaje = MensajesGlobales.Sucursal_No_Existe;
                return false;
            }
            if (usuarioId <= 0)
            {
                mensaje = MensajesGlobales.Usuario_No_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }
        public bool ValidarSalidaInventarioDetalle(int CantidadProducto, int loteId, out string mensaje)
        {
            if (CantidadProducto <= 0)
            {
                mensaje = MensajesGlobales.Cantidad_Producto_No_Valida;
                return false;
            }
            if (loteId <= 0)
            {
                mensaje = MensajesGlobales.Lote_No_Existe;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }
        public bool ValidarCostoTotalSucursal(decimal? costoTotalSucursal, out string mensaje)
        {
            decimal limiteCosto = 5000;

            if (costoTotalSucursal > limiteCosto)
            {
                mensaje = MensajesGlobales.Costo_Total_No_Valido;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }

        public bool ValidarRecepcion(SalidasInventario salidasInventario, out string mensaje)
        {
            if (!salidasInventario.Activo)
            {
                mensaje = MensajesGlobales.Salida_No_Existe;
                return false;
            }
            if (salidasInventario.EstadoId == (int)TypeEstadoSalidaInventario.Recibido)
            {
                mensaje = MensajesGlobales.Salida_Recepcionada;
                return false;
            }
            mensaje = MensajesGlobales.Exito;
            return true;
        }
    }
}
