using Academia.GestionInventario.WebApi._Infrastructure.Entities.Empleados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Estados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventarios;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventariosDetalles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;

namespace Academia.GestionInventario.WebApi._Common.Extensions
{
    public static class SalidaInventarioExtensor
    {
        public static int ObtenerTotalUnidades(this SalidasInventario salida, SalidasInventariosDetalle detalle)
        {
            if (detalle == null)
            {
                return 0;
            }
            return detalle.CantidadProducto;
        }

        public static decimal ObtenerTotalCosto(this SalidasInventario salida, SalidasInventariosDetalle detalle)
        {
            if (detalle == null)
            {
                return 0;
            }
            return salida.Total;
        }

        public static string ObtenerEstado(this Estado estadoItem)
        {
            if (estadoItem == null)
            {
                return "";
            }

            return estadoItem.Nombre;
        }

        public static string ObtenerUsuarioRecibeNombre(this Usuario usuarioRecibeItem, Empleado empleadoItem)
        {
            if (usuarioRecibeItem == null)
            {
                return "No Recibida";
            }
            return $"{empleadoItem.Nombre} {empleadoItem.Apellido}";
        }
        public static string ObtenerFechaRecibe(this SalidasInventario salida)
        {
            if (!salida.FechaRecibe.HasValue)
            {
                return "0000-00-00";
            }
            return salida.FechaRecibe.Value.ToString("yyyy-MM-dd");
        }

    }
}
