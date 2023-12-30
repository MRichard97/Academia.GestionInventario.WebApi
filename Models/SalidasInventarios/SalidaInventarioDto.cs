namespace Academia.GestionInventario.WebApi.Models.SalidasInventarios
{
    public class SalidaInventarioDto
    {
        public DateTime FechaSalida { get; set; }
        public decimal? Total { get; set; }
        public int EstadoId { get; set; }
        public int SucursalId { get; set; }
        public int UsuarioId { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int? UsuarioCreacionId { get; set; }
    }
}
