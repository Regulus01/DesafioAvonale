using Microsoft.EntityFrameworkCore;

namespace PaymentsAPI.Model.Context
{
    public class SqlServerContext : DbContext
    {

        protected SqlServerContext()
        {

        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        public DbSet<Payments> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payments>().HasData(new Payments
            {
                Id = 1,
                Value = 200.0,
                
            }
            );

            modelBuilder.Entity<Payments>().HasData(new Payments
            {
                Id = 2,
                Value = 50.0,

            });
        }
    }
}

