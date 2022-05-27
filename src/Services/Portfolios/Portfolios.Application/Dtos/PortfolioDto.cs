namespace Portfolios;

public record CreatePortfolioDto(string Id, string UserId, string Name) { 

    public static CreatePortfolioDto Map(Portfolio portfolio)
    {
        return new CreatePortfolioDto(portfolio.Id, portfolio.UserId, portfolio.Name);
    }
};

public record PortfolioDto(string Id, string UserId, string Name) {

    public static PortfolioDto Map(Portfolio portfolio)
    {
        return new PortfolioDto(portfolio.Id, portfolio.UserId, portfolio.Name);
    }
}