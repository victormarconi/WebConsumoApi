using Microsoft.EntityFrameworkCore;
using WebConsumoApi.Models;
using static WebConsumoApi.Models.VariationsDB;

namespace WebConsumoApi.DBContext
{
    public class VariationsContext : DbContext
    {
        public VariationsContext(DbContextOptions<VariationsContext> options) : base(options)
        {
        }
        public DbSet<Product_Variations> Variations { get; set; }
    }
}
