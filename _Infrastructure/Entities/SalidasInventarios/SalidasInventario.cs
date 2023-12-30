using Academia.GestionInventario.WebApi._Infrastructure.Entities.Estados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventariosDetalles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Sucursales;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;

namespace Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventarios;

public partial class SalidasInventario
{
    public int SalidaInventarioId { get; set; }

    public DateTime FechaSalida { get; set; }

    public decimal Total { get; set; }

    public DateTime? FechaRecibe { get; set; }

    public int? UsuarioRecibeId { get; set; }

    public int EstadoId { get; set; }

    public int SucursalId { get; set; }

    public int UsuarioId { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<SalidasInventariosDetalle> SalidasInventariosDetalles { get; set; } = new List<SalidasInventariosDetalle>();

    public virtual Sucursal Sucursal { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }

    public virtual Usuario? UsuarioRecibe { get; set; }
}
