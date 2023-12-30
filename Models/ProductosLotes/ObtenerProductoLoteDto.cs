namespace Academia.GestionInventario.WebApi.Models.ProductosLotes
{
    public class ObtenerProductoLoteDto
    {
        public int LoteId { get; set; }
        public decimal? Costo { get; set; }
        public int? Inventario { get; set; }
        public int ProductoId { get; set; }
        public string? NombreProducto { get; set; }
        public DateTime? FechaVencimiento { get; set; }
    }
}
