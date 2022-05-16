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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Macbook 13\" 8GB|256SSD|2.7Ghz",
                UnitaryValue = 8450.0,
                QtdEtoque = 5

            });
        }
    }
}
