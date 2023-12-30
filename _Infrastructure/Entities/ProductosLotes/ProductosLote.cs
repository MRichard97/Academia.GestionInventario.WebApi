using Academia.GestionInventario.WebApi._Infrastructure.Entities.Productos;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventariosDetalles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;

namespace Academia.GestionInventario.WebApi._Infrastructure.Entities.ProductosLotes;

public partial class ProductosLote
{
    public int LoteId { get; set; }

    public int? CantidadInicial { get; set; }

    public decimal? Costo { get; set; }

    public int? Inventario { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public int? ProductoId { get; set; }

    public bool Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual ICollection<SalidasInventariosDetalle> SalidasInventariosDetalles { get; set; } = new List<SalidasInventariosDetalle>();

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }
}
