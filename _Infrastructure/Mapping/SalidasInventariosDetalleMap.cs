using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventariosDetalles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia.GestionInventario.WebApi._Infrastructure.Mapping
{
    public class SalidasInventariosDetalleMap : IEntityTypeConfiguration<SalidasInventariosDetalle>
    {
        public void Configure(EntityTypeBuilder<SalidasInventariosDetalle> builder)
        {
            builder.HasKey(e => e.DetalleId);

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");

            builder.HasOne(d => d.Lote).WithMany(p => p.SalidasInventariosDetalles)
                .HasForeignKey(d => d.LoteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalidasInventariosDetalles_ProductosLotes");

            builder.HasOne(d => d.SalidaInventario).WithMany(p => p.SalidasInventariosDetalles)
                .HasForeignKey(d => d.SalidaInventarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalidasInventariosDetalles_SalidasInventarios");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.SalidasInventariosDetalleUsuarioCreacion)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_SalidasInventariosDetalles_UsuarioCreacion");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.SalidasInventariosDetalleUsuarioModificacion)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_SalidasInventariosDetalles_UsuarioModificacion");
        }
    }
}