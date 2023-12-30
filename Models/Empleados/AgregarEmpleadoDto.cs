namespace Academia.GestionInventario.WebApi.Models.Empleados
{
    public class AgregarEmpleadoDto
    {
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public bool Activo { get; set; } = true;
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;
        public int? UsuarioCreacionId { get; set; }
    }
}
