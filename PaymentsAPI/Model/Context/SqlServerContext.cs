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
    }
}

