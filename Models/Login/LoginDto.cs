namespace Academia.GestionInventario.WebApi.Models.Login
{
    public class LoginDto
    {
        public int? UsuarioId { get; set; }
        public string? Perfil { get; set; }
        public string? Usuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
    }
}
