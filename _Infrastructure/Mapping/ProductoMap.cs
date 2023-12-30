using Academia.GestionInventario.WebApi._Infrastructure.Entities.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia.GestionInventario.WebApi._Infrastructure.Mapping
{
    public class ProductoMap : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Producto");

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.ProductoUsuarioCreacion)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_Productos_UsuarioCreacion");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.ProductoUsuarioModificacion)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_Productos_UsuarioModificacion");
        }
    }
}