using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventarios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia.GestionInventario.WebApi._Infrastructure.Mapping
{
    public class SalidasInventariosMap : IEntityTypeConfiguration<SalidasInventario>
    {
        public void Configure(EntityTypeBuilder<SalidasInventario> builder)
        {
            builder.HasKey(e => e.SalidaInventarioId).HasName("PK_SalidaInventarios");

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Estado).WithMany(p => p.SalidasInventarios)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalidaInventarios_Estados");

            builder.HasOne(d => d.Sucursal).WithMany(p => p.SalidasInventarios)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalidaInventarios_Sucursales");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.SalidasInventarioUsuarioCreacion)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_SalidaInventarios_UsuarioCreacion");

            builder.HasOne(d => d.Usuario).WithMany(p => p.SalidasInventarioUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalidaInventarios_Usuarios");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.SalidasInventarioUsuarioModificacion)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_SalidaInventarios_UsuarioModificacion");

            builder.HasOne(d => d.UsuarioRecibe).WithMany(p => p.SalidasInventarioUsuarioRecibe)
                .HasForeignKey(d => d.UsuarioRecibeId)
                .HasConstraintName("FK_SalidaInventarios_UsuarioRecibe");
        }
    }
}