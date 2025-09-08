using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PedidoAPI.Infrastructure.Db;

namespace PedidoAPI.Infrastructure.Db
{
    public class PedidoContextFactory : IDesignTimeDbContextFactory<PedidoContext>
    {
        public PedidoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PedidoContext>();

            optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress; Initial Catalog=OrdemServico;Integrated Security=True;TrustServerCertificate=True;");

            return new PedidoContext(optionsBuilder.Options);
        }
    }
}