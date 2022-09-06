using InvestmentService.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace InvestmentService.DataAccess
{
    public class InvestmentServiceDbContext : DbContext
    {
        public InvestmentServiceDbContext(DbContextOptions<InvestmentServiceDbContext> dbContextOptions) : base(dbContextOptions) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<CustomerInfo> CustomerInfo { get; set; } = null!;
        public DbSet<ConsultantInfo> ConsultantInfo { get; set; } = null!;
        public DbSet<DiscretionaryRule> DiscretionaryRules { get; set; } = null!;
    }
}
