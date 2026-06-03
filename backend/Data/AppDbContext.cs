using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        public DbSet<Clientes> Clientes {get; set;}
        public DbSet<Pedidos> Pedidos {get; set;}
    }
}