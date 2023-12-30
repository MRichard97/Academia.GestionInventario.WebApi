namespace Academia.GestionInventario.WebApi.Models.Usuarios
{
    public class AgregarUsuarioDto
    {
        public string? Nombre { get; set; }
        public string? Clave { get; set; }
        public int? EmpleadoId { get; set; }
        public int? PerfilId { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;
        public int? UsuarioCreacionId { get; set; }
    }
}
