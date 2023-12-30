namespace Academia.GestionInventario.WebApi.Models.Sucursales
{
    public class AgregarSucursalDto
    {
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public int? UsuarioCreacionId { get; set; }
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;
    }
}
