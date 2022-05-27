using Portfolios.Domain.Commom;

namespace Portfolios;

public class Portfolio : BaseEntity<string>
{
    public Portfolio(string userId, string name)
    {
        Id = Guid.NewGuid().ToString();
        UserId = userId;
        Name = name;
    }
    public string UserId { get; set; }
    public string Name { get; set; }
    public decimal TotalSpent { get; set; }
    public decimal TotalInvest { get; set; }
}
