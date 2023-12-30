namespace Academia.GestionInventario.WebApi.Models.Sucursales
{
    public class ObtenerSucursalDto
    {
        public int SucursalId { get; set; }
        public string? Nombre { get; set; }
        public bool Activo { get; set; }
    }
}
