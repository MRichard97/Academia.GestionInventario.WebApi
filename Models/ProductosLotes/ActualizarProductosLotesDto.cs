namespace Academia.GestionInventario.WebApi.Models.ProductosLotes
{
    public class ActualizarProductosLotesDto
    {
        public int? LoteId { get; set; }
        public int? CantidadInicial { get; set; }
        public decimal? Costo { get; set; }
        public int? Inventario { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? ProductoId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
    }
}
