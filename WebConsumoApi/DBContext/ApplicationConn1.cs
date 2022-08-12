using Microsoft.EntityFrameworkCore;
using WebConsumoApi.Models;

namespace WebConsumoApi.DBContext
{
    public class ApplicationConn1 : DbContext
    {
        public ApplicationConn1(DbContextOptions<ApplicationConn1> options)
        {

        }

        public DbSet<ProdutoDB> _ProdutoDB { get; set; }
    }
}
