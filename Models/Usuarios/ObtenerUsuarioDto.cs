namespace Academia.GestionInventario.WebApi.Models.Usuarios
{
    public class ObtenerUsuarioDto
    {
        public int? UsuarioId { get; set; }
        public string? Nombre { get; set; }
        public string? NombreEmpleado { get; set; }
        public int? EmpleadoId { get; set; }
        public int? PerfilId { get; set; }
        public string? Perfil { get; set; }
        public bool Activo { get; set; }
    }
}
