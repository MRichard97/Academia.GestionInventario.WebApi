using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;

namespace Academia.GestionInventario.WebApi._Infrastructure.Entities.Perfiles;

public partial class Perfil
{
    public int PerfilId { get; set; }

    public string? Nombre { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioCreacionId { get; set; }

    public int? UsuarioModificacionId { get; set; }

    public virtual Usuario? UsuarioCreacion { get; set; }

    public virtual Usuario? UsuarioModificacion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
