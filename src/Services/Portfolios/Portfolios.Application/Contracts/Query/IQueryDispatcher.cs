using Portfolios.Domain.Commom;

namespace Portfolios.Application.Contracts
{
    public interface IQueryDispatcher
    {
        Task<TQueryResult> Dispatch<TQueryResult>(IQuery<TQueryResult> query, CancellationToken cancellation = default);
    }
}