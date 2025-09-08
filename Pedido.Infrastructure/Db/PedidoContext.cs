using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PedidoAPI.Domain.Entities;

namespace PedidoAPI.Infrastructure.Db
{
    public class PedidoContext : DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoInPedido> ProdutosInPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoInPedido>()
                .HasKey(p => new { p.PedidoId, p.ProdutoId });

            modelBuilder.Entity<ProdutoInPedido>()
            .HasOne(p => p.Pedido)
            .WithMany(ped => ped.ItensDoPedido)
            .HasForeignKey(p => p.PedidoId);
        }
    }
}