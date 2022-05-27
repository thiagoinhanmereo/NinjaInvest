using Portfolios.Domain.Commom;

namespace Portfolios.Application.Commands
{
    public class CreatePortfolioCommand : ICommand<CreatePortfolioCommandResponse>
    {
        public CreatePortfolioCommand(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
