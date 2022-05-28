using Portfolios.Application.Contracts.Persistence;
using Portfolios.Persistence.Context;

namespace Portfolios.Persistence.Repositories
{
    public class PortfolioRepository : GenericRepository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(PortfoliosDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> PortfolioNameIsDuplicatedForUser(string userId, string name)
        {
            var matches = _dbContext.Portfolios.Any(e => e.UserId == userId && e.Name.ToLower().Equals(name.ToLower()));
            return Task.FromResult(matches);
        }
    }
}
