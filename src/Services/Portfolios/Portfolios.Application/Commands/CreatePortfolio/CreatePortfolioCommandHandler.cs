using Portfolios.Application.Contracts;
using Portfolios.Domain.Commom;

namespace Portfolios.Application.Commands
{
    public class CreatePortfolioCommandHandler : ICommandHandler<CreatePortfolioCommand, CreatePortfolioCommandResponse>
    {
        public async Task<CreatePortfolioCommandResponse> Handle(CreatePortfolioCommand command, CancellationToken cancellation)
        {
            return new CreatePortfolioCommandResponse();
        }
    }
}
