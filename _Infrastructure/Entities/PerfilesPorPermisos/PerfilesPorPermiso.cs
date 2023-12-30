using Academia.GestionInventario.WebApi._Infrastructure.Entities.Perfiles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Permisos;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;

namespace Academia.GestionInventario.WebApi._Infrastructure.Entities.PerfilesPorPermisos;

public partial class PerfilesPorPermiso
{
    public int PerfilId { get; set; }

    public int PermisoId { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public virtual Perfil Perfil { get; set; } = null!;

    public virtual Permiso Permiso { get; set; } = null!;

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }
}
