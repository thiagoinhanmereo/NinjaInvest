using Portfolios.Domain.Commom;

namespace Portfolios.Application.Commands
{
    public class CreatePortfolioCommandResponse : BaseResponse<string>
    {
        public CreatePortfolioCommandResponse(): base()
        {

        }

        public CreatePortfolioDto CreatePortfolioDto { get; set; }
    }
}
