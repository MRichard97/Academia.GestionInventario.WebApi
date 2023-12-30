namespace Academia.GestionInventario.WebApi.Models.Sucursales
{
    public class ActualizarSucursalDto
    {
        public int? SucursalId { get; set; }
        public string Nombre { get; set; } = null!;
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacionId { get; set; }

    }
}
