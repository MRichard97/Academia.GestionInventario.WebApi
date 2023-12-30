using Academia.GestionInventario.WebApi._Infrastructure.Entities.ProductosLotes;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventarios;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;

namespace Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventariosDetalles;

public partial class SalidasInventariosDetalle
{
    public int DetalleId { get; set; }

    public int CantidadProducto { get; set; }

    public int SalidaInventarioId { get; set; }

    public int LoteId { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public virtual ProductosLote Lote { get; set; } = null!;

    public virtual SalidasInventario SalidaInventario { get; set; } = null!;

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }
}
