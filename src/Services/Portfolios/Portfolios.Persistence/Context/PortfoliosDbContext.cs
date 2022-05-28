using Microsoft.EntityFrameworkCore;

namespace Portfolios.Persistence.Context
{
    public class PortfoliosDbContext : DbContext
    {
        public PortfoliosDbContext(DbContextOptions<PortfoliosDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking; //Check this later
        }

        public DbSet<Portfolio> Portfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(PortfoliosDbContext).Assembly);
        }
    }
}
