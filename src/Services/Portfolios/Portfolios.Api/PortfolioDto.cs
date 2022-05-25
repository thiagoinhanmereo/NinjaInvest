namespace Portfolios;

public record PortfolioDto(string Id, string UserId, string Name) { 

    public static PortfolioDto Map(Portfolio portfolio)
    {
        return new PortfolioDto(portfolio.Id, portfolio.UserId, portfolio.Name);
    }
};
public record CreatePortfolioDto(string UserId, string Name);