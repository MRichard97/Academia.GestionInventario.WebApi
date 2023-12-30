namespace Academia.GestionInventario.WebApi.Models.Empleados
{
    public class ObtenerEmpleadoDto
    {
        public int EmpleadoId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public bool Activo { get; set; }
    }
}
