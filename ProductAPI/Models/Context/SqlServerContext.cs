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

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Notebook i5",
                UnitaryValue = 5000.0,
                QtdEtoque = 10

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                Name = "Computador i9",
                UnitaryValue = 7000,
                QtdEtoque = 15

            });


            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                Name = "PS4 1T",
                UnitaryValue = 2000,
                QtdEtoque = 20

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 5,
                Name = "Nintendo Switch OLED",
                UnitaryValue = 4000,
                QtdEtoque = 50

            });
        }
    }
}
