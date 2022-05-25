using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        IConfiguration configuration;
        public ApplicationContext(IConfiguration conf) { 
            configuration = conf;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MSSQL"));
        }
    }
}
