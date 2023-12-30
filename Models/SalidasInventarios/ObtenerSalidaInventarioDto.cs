using System.Text.Json.Serialization;

namespace Academia.GestionInventario.WebApi.Models.SalidasInventarios
{
    public class ObtenerSalidaInventarioDto
    {
        public int SalidaId { get; set; }
        [JsonIgnore]
        public int SucursalId { get; set; }
        public string? NombreProducto { get; set; }
        public DateTime FechaSalida { get; set; }
        public string? Estado { get; set; }
        public int TotalUnidades { get; set; }
        public decimal TotalCosto { get; set; }
        public string? UsuarioRecibe { get; set; }
        public string? FechaRecibe { get; set; }
    }
}
