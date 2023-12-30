using Academia.GestionInventario.WebApi._Infrastructure.Entities.Empleados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Estados;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Perfiles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.PerfilesPorPermisos;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Permisos;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Productos;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.ProductosLotes;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventarios;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.SalidasInventariosDetalles;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Sucursales;
using Academia.GestionInventario.WebApi._Infrastructure.Entities.Usuarios;
using Academia.GestionInventario.WebApi._Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Academia.GestionInventario.WebApi._Infrastructure
{
    public class GestionInventarioDbContext : DbContext
    {
        public GestionInventarioDbContext(DbContextOptions<GestionInventarioDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Empleado> Empleados { get; set; }

        public virtual DbSet<Estado> Estados { get; set; }

        public virtual DbSet<Perfil> Perfiles { get; set; }

        public virtual DbSet<PerfilesPorPermiso> PerfilesPorPermisos { get; set; }

        public virtual DbSet<Permiso> Permisos { get; set; }

        public virtual DbSet<Producto> Productos { get; set; }

        public virtual DbSet<ProductosLote> ProductosLotes { get; set; }

        public virtual DbSet<SalidasInventario> SalidasInventarios { get; set; }

        public virtual DbSet<SalidasInventariosDetalle> SalidasInventariosDetalles { get; set; }

        public virtual DbSet<Sucursal> Sucursales { get; set; }

        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new EmpleadoMap());
            modelBuilder.ApplyConfiguration(new EstadoMap());
            modelBuilder.ApplyConfiguration(new PerfilesPorPermisoMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new PermisoMap());
            modelBuilder.ApplyConfiguration(new ProductoMap());
            modelBuilder.ApplyConfiguration(new ProductosLoteMap());
            modelBuilder.ApplyConfiguration(new SalidasInventariosMap());
            modelBuilder.ApplyConfiguration(new SalidasInventariosDetalleMap());
            modelBuilder.ApplyConfiguration(new SucursalMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
