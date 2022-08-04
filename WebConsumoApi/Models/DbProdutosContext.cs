using Microsoft.EntityFrameworkCore;

namespace WebConsumoApi.Models.ViewModels
{
    public class DbProdutosContext : DbContext
    {
        public DbProdutosContext(DbContextOptions<DbProdutosContext> options) : base(options)
        {

        }
        public DbSet<ProdutoDB> Produtos { get; set; }
    }
}
