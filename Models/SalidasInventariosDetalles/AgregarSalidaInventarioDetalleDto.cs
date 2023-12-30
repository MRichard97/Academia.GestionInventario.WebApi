namespace Academia.GestionInventario.WebApi.Models.SalidasInventariosDetalles
{
    public class AgregarSalidaInventarioDetalleDto
    {
        public int CantidadProducto { get; set; }

        public int LoteId { get; set; }

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int? UsuarioCreacionId { get; set; }

    }
}
