using Portfolios.Domain.Commom;

namespace Portfolios.Application.Contracts
{
    public interface ICommandHandler<TCommand, TCommandResult> where TCommand : ICommand<TCommandResult> 
    {
        Task<TCommandResult> Handle(TCommand command, CancellationToken cancellation = default);
    }   
}