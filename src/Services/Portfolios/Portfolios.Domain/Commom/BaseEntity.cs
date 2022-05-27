namespace Portfolios.Domain.Commom
{
    public abstract class BaseEntity<Tkey> : IHasKey<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
