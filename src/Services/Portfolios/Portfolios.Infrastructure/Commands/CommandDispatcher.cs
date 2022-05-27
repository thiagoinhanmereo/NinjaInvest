using Portfolios.Application.Contracts;
using Portfolios.Domain.Commom;

namespace Portfolios.Infrastructure
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<TCommandResult> Dispatch<TCommandResult>(ICommand<TCommandResult> command, CancellationToken cancellation = default)
        {
            var type = typeof(ICommandHandler<,>);
            var argTypes = new Type[] { command.GetType(), typeof(TCommandResult) };
            var handlerType = type.MakeGenericType(argTypes);

            dynamic? handler = _serviceProvider.GetService(handlerType) ?? throw new InvalidOperationException($"Could not create a handler for type {handlerType}");
            return await handler.Handle((dynamic)command, cancellation);
        }
    }
}