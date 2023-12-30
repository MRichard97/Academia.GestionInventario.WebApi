namespace Academia.GestionInventario.WebApi.Models.Usuarios
{
    public class ActualizarUsuarioDto
    {
        public int? UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? Clave { get; set; }
        public int? EmpleadoId { get; set; }
        public int? PerfilId { get; set; }
        public DateTime? FechaModificacion { get; set; } = DateTime.Now;
        public int? UsuarioModificacionId { get; set; }
    }
}
