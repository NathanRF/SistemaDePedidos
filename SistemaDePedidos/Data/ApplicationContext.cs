using Microsoft.EntityFrameworkCore;
using SistemaDePedidos.Data.Configurations;
using SistemaDePedidos.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaDePedidos.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PedidoItem> PedidoItem { get; set; }
        public DbSet<Produto> Produto { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Settings.SqlServerConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}
