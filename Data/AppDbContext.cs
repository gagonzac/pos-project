using Microsoft.EntityFrameworkCore;
using PosTestApi.Models;

namespace PosTestApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Venta> Ventas { get; set; }

    public DbSet<DetalleVenta> DetalleVentas { get; set; }
}