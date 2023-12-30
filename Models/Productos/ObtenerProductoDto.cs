namespace Academia.GestionInventario.WebApi.Models.Productos
{
    public class ObtenerProductoDto
    {
        public int ProductoId { get; set; }
        public string? Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
