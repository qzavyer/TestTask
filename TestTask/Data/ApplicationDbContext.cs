using Microsoft.EntityFrameworkCore;
using TestTask.Data.Configurations;

namespace TestTask.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new GoodConfiguration());
            builder.ApplyConfiguration(new OrderGoodConfiguration());

            base.OnModelCreating(builder);
        }
    }
}