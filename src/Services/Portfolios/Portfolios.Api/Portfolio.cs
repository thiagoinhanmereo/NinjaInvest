namespace Portfolios;

public class Portfolio
{
    public Portfolio(string userId, string name)
    {
        Id = Guid.NewGuid().ToString();
        UserId = userId;
        Name = name;
    }
    public string Id { get; set; } //TODO create base entity
    public string UserId { get; set; }
    public string Name { get; set; }
    public decimal TotalSpent { get; set; }
    public decimal TotalInvest { get; set; }
}
