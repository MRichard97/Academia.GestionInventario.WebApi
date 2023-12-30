using Academia.GestionInventario.WebApi._Infrastructure.Entities.PerfilesPorPermisos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia.GestionInventario.WebApi._Infrastructure.Mapping
{
    public class PerfilesPorPermisoMap : IEntityTypeConfiguration<PerfilesPorPermiso>
    {
        public void Configure(EntityTypeBuilder<PerfilesPorPermiso> builder)
        {
            builder.HasNoKey();

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");

            builder.HasOne(d => d.Perfil).WithMany()
                .HasForeignKey(d => d.PerfilId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilesPorPermisos_Perfiles");

            builder.HasOne(d => d.Permiso).WithMany()
                .HasForeignKey(d => d.PermisoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerfilesPorPermisos_Permisos");

            builder.HasOne(d => d.UsuarioCreacion).WithMany()
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_PerfilesPorPermisos_UsuarioCreacion");

            builder.HasOne(d => d.UsuarioModificacion).WithMany()
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_PerfilesPorPermisos_UsuarioModificacion");
        }
    }
}