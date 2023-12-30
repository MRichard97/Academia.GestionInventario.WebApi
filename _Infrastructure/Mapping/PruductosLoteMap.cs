using Academia.GestionInventario.WebApi._Infrastructure.Entities.ProductosLotes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia.GestionInventario.WebApi._Infrastructure.Mapping
{
    public class ProductosLoteMap : IEntityTypeConfiguration<ProductosLote>
    {
        public void Configure(EntityTypeBuilder<ProductosLote> builder)
        {
            builder.HasKey(e => e.LoteId);

            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.Costo).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");

            builder.HasOne(d => d.Producto).WithMany(p => p.ProductosLotes)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductosLotes_ProductoId");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.ProductosLoteUsuarioCreacion)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_ProductosLotes_UsuarioCreacion");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.ProductosLoteUsuarioModificacion)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_ProductosLotes_UsuarioModificacion");
        }
    }
}