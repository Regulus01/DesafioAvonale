using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Models.Context
{
    public class SqlServerContext : DbContext
    {
        protected SqlServerContext()
        {

        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }    
    }
}
