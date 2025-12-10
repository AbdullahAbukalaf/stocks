using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using api.Data.Configuration;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Scans assembly for IEntityTypeConfiguration implementations (keeps it flexible)
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}
