using Microsoft.EntityFrameworkCore;
using SistemaAgenciaAutomotriz.Dominio.Entities;

namespace SistemaAgenciaAutomotriz.Datos.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
    public DbSet<Venta> Ventas => Set<Venta>();
    public DbSet<VentaDetalle> VentaDetalles => Set<VentaDetalle>();
    public DbSet<MovimientoInventario> MovimientosInventario => Set<MovimientoInventario>();
    public DbSet<CuentaPorCobrar> CuentasPorCobrar => Set<CuentaPorCobrar>();
    public DbSet<Abono> Abonos => Set<Abono>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Username).HasMaxLength(50).IsRequired();
            entity.Property(e => e.PasswordHash).HasMaxLength(255).IsRequired();
            entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
            entity.HasIndex(e => e.Username).IsUnique();
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(150).IsRequired();
            entity.Property(e => e.RFC).HasMaxLength(13);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.Licencia).HasMaxLength(20);
            entity.Property(e => e.INE).HasMaxLength(20);
            entity.Property(e => e.TelefonoEmergencia).HasMaxLength(20);
            entity.Property(e => e.ContactoEmergencia).HasMaxLength(150);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nombre).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Descripcion).HasMaxLength(250);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Codigo).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Nombre).HasMaxLength(150).IsRequired();
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Precio).HasPrecision(18, 2);
            entity.Property(e => e.Costo).HasPrecision(18, 2);
            entity.HasIndex(e => e.Codigo).IsUnique();
            entity.HasOne(e => e.Categoria)
                  .WithMany(c => c.Productos)
                  .HasForeignKey(e => e.CategoriaId)
                  .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.VIN).HasMaxLength(17).IsRequired();
            entity.Property(e => e.Marca).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Modelo).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Color).HasMaxLength(30);
            entity.Property(e => e.Precio).HasPrecision(18, 2);
            entity.Property(e => e.Costo).HasPrecision(18, 2);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.ImagenPath).HasMaxLength(250);
            entity.Property(e => e.Motor).HasMaxLength(50);
            entity.Property(e => e.Transmision).HasMaxLength(30);
            entity.Property(e => e.Combustible).HasMaxLength(30);
            entity.HasIndex(e => e.VIN).IsUnique();
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Subtotal).HasPrecision(18, 2);
            entity.Property(e => e.IVA).HasPrecision(18, 2);
            entity.Property(e => e.Total).HasPrecision(18, 2);
            entity.Property(e => e.Enganche).HasPrecision(18, 2);
            entity.Property(e => e.MontoFinanciado).HasPrecision(18, 2);
            entity.Property(e => e.TasaInteres).HasPrecision(5, 2);
            entity.Property(e => e.Mensualidad).HasPrecision(18, 2);
            entity.Property(e => e.CostoSeguro).HasPrecision(18, 2);
            entity.HasOne(e => e.Cliente)
                  .WithMany(c => c.Ventas)
                  .HasForeignKey(e => e.ClienteId)
                  .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Vehiculo)
                  .WithMany()
                  .HasForeignKey(e => e.VehiculoId)
                  .OnDelete(DeleteBehavior.SetNull);
            entity.HasOne(e => e.Usuario)
                  .WithMany()
                  .HasForeignKey(e => e.UsuarioId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<VentaDetalle>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.PrecioUnitario).HasPrecision(18, 2);
            entity.Property(e => e.Importe).HasPrecision(18, 2);
            entity.HasOne(e => e.Venta)
                  .WithMany(v => v.Detalles)
                  .HasForeignKey(e => e.VentaId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Producto)
                  .WithMany(p => p.VentaDetalles)
                  .HasForeignKey(e => e.ProductoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<MovimientoInventario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Cantidad).IsRequired();
            entity.Property(e => e.Motivo).HasMaxLength(250);
            entity.HasOne(e => e.Producto)
                  .WithMany(p => p.Movimientos)
                  .HasForeignKey(e => e.ProductoId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Usuario)
                  .WithMany()
                  .HasForeignKey(e => e.UsuarioId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CuentaPorCobrar>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Total).HasPrecision(18, 2);
            entity.Property(e => e.Pagado).HasPrecision(18, 2);
            entity.HasOne(e => e.Venta)
                  .WithOne(v => v.CuentaPorCobrar)
                  .HasForeignKey<CuentaPorCobrar>(e => e.VentaId)
                  .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Cliente)
                  .WithMany(c => c.CuentasPorCobrar)
                  .HasForeignKey(e => e.ClienteId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Abono>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Monto).HasPrecision(18, 2);
            entity.Property(e => e.Observaciones).HasMaxLength(250);
            entity.HasOne(e => e.CuentaPorCobrar)
                  .WithMany(c => c.Abonos)
                  .HasForeignKey(e => e.CuentaPorCobrarId)
                  .OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.Usuario)
                  .WithMany()
                  .HasForeignKey(e => e.UsuarioId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}