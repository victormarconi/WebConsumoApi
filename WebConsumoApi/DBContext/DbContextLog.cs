using Microsoft.EntityFrameworkCore;
using WebConsumoApi.Models;

namespace WebConsumoApi.DBContext
{
    public class DbContextLog : DbContext
    {
        public DbContextLog(DbContextOptions<DbContextLog> options) : base(options)
        {
        }
        public DbSet<Log> Log { get; set; }
    }
}