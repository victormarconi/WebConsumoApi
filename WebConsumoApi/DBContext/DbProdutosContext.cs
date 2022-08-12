using Microsoft.EntityFrameworkCore;
using WebConsumoApi.Models;

namespace WebConsumoApi.DBContext
{
    public class DbProdutosContext : DbContext
    {
        public DbProdutosContext(DbContextOptions<DbProdutosContext> options) : base(options)
        {
        }
        public DbSet<ProdutoDB> Produtos { get; set; }
    }
}
