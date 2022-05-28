namespace Portfolios.Application.Contracts.Persistence
{
    public interface IPortfolioRepository : IGenericRepositoryAsync<Portfolio>
    {
        Task<bool> PortfolioNameIsDuplicatedForUser(string userId, string name);
    }
}
