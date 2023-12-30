namespace Academia.GestionInventario.WebApi.Models.Productos
{
    public class ActualizarProductoDto
    {
        public int? ProductoId { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacionId { get; set; }
    }
}
