using Academia.GestionInventario.WebApi._Infrastructure.Entities.Permisos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia.GestionInventario.WebApi._Infrastructure.Mapping
{
    public class PermisoMap : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Permiso");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.PermisoUsuarioCreacion)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_Permisos_UsuarioCreacion");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.PermisoUsuarioModificacion)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_Permisos_UsuarioModificacion");
        }
    }
}