namespace Academia.GestionInventario.WebApi.Models.Productos
{
    public class AgregarProductoDto
    {
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? UsuarioCreacionId { get; set; }
    }
}
