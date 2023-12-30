namespace Academia.GestionInventario.WebApi.Models.Empleados
{
    public class ActualizarEmpleadoDto
    {
        public int? EmpleadoId { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacionId { get; set; }

    }
}
