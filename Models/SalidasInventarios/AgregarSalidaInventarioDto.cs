namespace Academia.GestionInventario.WebApi.Models.SalidasInventarios
{
    public class AgregarSalidaInventarioDto
    {
        public int SucursalId { get; set; }
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadProducto { get; set; }
    }
}
