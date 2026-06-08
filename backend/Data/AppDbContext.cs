using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<ItensMenu> ItensMenu { get; set; }
        public DbSet<PedidosItensMenu> PedidosItensMenu { get; set; }
        public DbSet<Pagamentos> Pagamentos { get; set; }
        public DbSet<Endereco> Endereco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedidos>()
            .HasOne(p => p.Clientes)
            .WithMany(c => c.Pedidos) // Se removeu a lista da classe Clientes, use apenas .WithMany()
            .HasForeignKey(p => p.ClientesID)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull); // Muda o "ON DELETE CASCADE" para "SET NULL"

            // Corrige 1:1 do Endereço
            modelBuilder.Entity<Pedidos>()
                .HasOne(p => p.Endereco)
                .WithOne(e => e.Pedidos)
                .HasForeignKey<Endereco>(e => e.PedidosID)
                .IsRequired(false); // Permite que pedidos de mesa/balcão não tenham endereço

            // Corrige 1:1 do Pagamento
            modelBuilder.Entity<Pedidos>()
                .HasOne(p => p.Pagamentos)
                .WithOne(pg => pg.Pedidos)
                .HasForeignKey<Pagamentos>(pg => pg.PedidosID)
                .IsRequired(false); // O pagamento pode ser inserido depois do pedido criado
        }

    }
}