using Academia.GestionInventario.WebApi._Infrastructure.Entities.Empleados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Estados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Perfiles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Permisos;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Productos;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.ProductosLotes;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventarios;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventariosDetalles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Sucursales;

namespace Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;

public partial class Usuario
{
    public int? UsuarioId { get; set; }

    public string? Nombre { get; set; } = null!;

    public string? Clave { get; set; } = null!;

    public int? EmpleadoId { get; set; }

    public int? PerfilId { get; set; }

    public bool Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual ICollection<Empleado> EmpleadoUsuarioCreacion { get; set; } = new List<Empleado>();

    public virtual ICollection<Empleado> EmpleadoUsuarioModificacion { get; set; } = new List<Empleado>();

    public virtual ICollection<Estado> EstadoUsuarioCreacion { get; set; } = new List<Estado>();

    public virtual ICollection<Estado> EstadoUsuarioModificacion { get; set; } = new List<Estado>();

    public virtual ICollection<Usuario> InverseUsuarioCreacion { get; set; } = new List<Usuario>();

    public virtual ICollection<Usuario> InverseUsuarioModificacion { get; set; } = new List<Usuario>();

    public virtual Perfil Perfil { get; set; } = null!;

    public virtual ICollection<Perfil> PerfileUsuarioCreacion { get; set; } = new List<Perfil>();

    public virtual ICollection<Perfil> PerfileUsuarioModificacion { get; set; } = new List<Perfil>();

    public virtual ICollection<Permiso> PermisoUsuarioCreacion { get; set; } = new List<Permiso>();

    public virtual ICollection<Permiso> PermisoUsuarioModificacion { get; set; } = new List<Permiso>();

    public virtual ICollection<Producto> ProductoUsuarioCreacion { get; set; } = new List<Producto>();

    public virtual ICollection<Producto> ProductoUsuarioModificacion { get; set; } = new List<Producto>();

    public virtual ICollection<ProductosLote> ProductosLoteUsuarioCreacion { get; set; } = new List<ProductosLote>();

    public virtual ICollection<ProductosLote> ProductosLoteUsuarioModificacion { get; set; } = new List<ProductosLote>();

    public virtual ICollection<SalidasInventario> SalidasInventarioUsuarioCreacion { get; set; } = new List<SalidasInventario>();

    public virtual ICollection<SalidasInventario> SalidasInventarioUsuarioModificacion { get; set; } = new List<SalidasInventario>();

    public virtual ICollection<SalidasInventario> SalidasInventarioUsuarioRecibe { get; set; } = new List<SalidasInventario>();

    public virtual ICollection<SalidasInventario> SalidasInventarioUsuarios { get; set; } = new List<SalidasInventario>();

    public virtual ICollection<SalidasInventariosDetalle> SalidasInventariosDetalleUsuarioCreacion { get; set; } = new List<SalidasInventariosDetalle>();

    public virtual ICollection<SalidasInventariosDetalle> SalidasInventariosDetalleUsuarioModificacion { get; set; } = new List<SalidasInventariosDetalle>();

    public virtual ICollection<Sucursal> SucursalUsuarioCreacion { get; set; } = new List<Sucursal>();

    public virtual ICollection<Sucursal> SucursalUsuarioModificacion { get; set; } = new List<Sucursal>();

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }
}
