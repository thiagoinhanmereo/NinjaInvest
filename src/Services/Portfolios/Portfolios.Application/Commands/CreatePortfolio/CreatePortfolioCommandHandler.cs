using Portfolios.Application.Contracts;
using Portfolios.Application.Contracts.Persistence;

namespace Portfolios.Application.Commands
{
    public class CreatePortfolioCommandHandler : ICommandHandler<CreatePortfolioCommand, CreatePortfolioCommandResponse>
    {
        private readonly IPortfolioRepository _portfolioRepository;

        public CreatePortfolioCommandHandler(IPortfolioRepository portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<CreatePortfolioCommandResponse> Handle(CreatePortfolioCommand command, CancellationToken cancellation)
        {
            //UserId will be hardcoded while auth is not ready
            var userId = "6f2a8888-de3c-4803-af04-aff58f6c3cfe";
            var createPortfolioCommandResponse = new CreatePortfolioCommandResponse();
            var validator = new CreatePortfolioCommandValidator(_portfolioRepository, userId);
            var validationResult = await validator.ValidateAsync(command, cancellation);

            if (validationResult.Errors.Any())
            {
                createPortfolioCommandResponse.Success = false;

                foreach (var error in validationResult.Errors)
                {
                    createPortfolioCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }

            if (createPortfolioCommandResponse.Success)
            {
                var portfolio = new Portfolio(userId, command.Name);
                portfolio = await _portfolioRepository.AddAsync(portfolio);
                createPortfolioCommandResponse.CreatePortfolioDto = CreatePortfolioDto.Map(portfolio);
            }

            return createPortfolioCommandResponse;
        }
    }
}