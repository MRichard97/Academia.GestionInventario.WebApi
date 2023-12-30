using Academia.GestionInventario.WebApi._Infrastructure.Entities.Empleados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Academia.GestionInventario.WebApi._Infrastructure.Mapping
{
    public class EmpleadoMap : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.Property(e => e.Activo).HasDefaultValue(true);
            builder.Property(e => e.Apellido)
                .HasMaxLength(150)
                .IsUnicode(false);
            builder.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            builder.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.HasOne(d => d.UsuarioCreacion).WithMany(p => p.EmpleadoUsuarioCreacion)
                .HasForeignKey(d => d.UsuarioCreacionId)
                .HasConstraintName("FK_Empleados_UsuarioCreacion");

            builder.HasOne(d => d.UsuarioModificacion).WithMany(p => p.EmpleadoUsuarioModificacion)
                .HasForeignKey(d => d.UsuarioModificacionId)
                .HasConstraintName("FK_Empleados_UsuarioModificacion");
        }
    }
}