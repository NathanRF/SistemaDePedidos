using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Domain;

namespace SistemaDePedidos.Data
{
  public class ApplicationContext : DbContext
  {
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<PedidoItem> PedidoItens { get; set; }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //optionsBuilder.UseSqlServer(Settings.SqlServerConnectionString);
      optionsBuilder.UseSqlite(Settings.SqliteConnectionString);
      //optionsBuilder.LogTo(System.Console.WriteLine);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
  }
}
