using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        public DbSet<Cliente> Cliente {get; set;}
        public DbSet<Pedido> Pedido {get; set;}
        public DbSet<Mesa> Mesa {get; set;}
        public DbSet<ItensMenu> ItensMenu {get; set;}
        public DbSet<PedidosItensMenu> PedidosItensMenu {get; set;}
        
    }
}