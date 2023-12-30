namespace Academia.GestionInventario.WebApi.Models.ProductosLotes
{
    public class AgregarProductosLoteDto
    {
        public int? CantidadInicial { get; set; }
        public decimal? Costo { get; set; }
        public int? Inventario { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? ProductoId { get; set; }
        public bool Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? UsuarioCreacionId { get; set; }
    }
}
