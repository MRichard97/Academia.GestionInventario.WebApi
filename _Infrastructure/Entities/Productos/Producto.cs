using Academia.GestionInventario.WebApi._Infrastructure.Entities.ProductosLotes;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;

namespace Academia.GestionInventario.WebApi._Infrastructure.Entities.Productos;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string? Nombre { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public virtual ICollection<ProductosLote> ProductosLotes { get; set; } = new List<ProductosLote>();

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }
}
