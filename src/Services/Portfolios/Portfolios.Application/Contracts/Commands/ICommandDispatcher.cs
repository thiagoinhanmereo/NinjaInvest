using Portfolios.Domain.Commom;

namespace Portfolios.Application.Contracts
{
    public interface ICommandDispatcher
    {
        Task<TCommandResult> Dispatch<TCommandResult>(ICommand<TCommandResult> command, CancellationToken cancellation = default);
    }
}