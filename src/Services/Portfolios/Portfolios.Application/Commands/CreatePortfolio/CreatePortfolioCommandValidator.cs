using FluentValidation;
using Portfolios.Application.Contracts.Persistence;

namespace Portfolios.Application.Commands
{
    public class CreatePortfolioCommandValidator : AbstractValidator<CreatePortfolioCommand>
    {
        private readonly IPortfolioRepository _portfolioRepository;
        private readonly string _userId;
        public CreatePortfolioCommandValidator(IPortfolioRepository portfolioRepository, string userId) //Remove userId from here
        {
            _portfolioRepository = portfolioRepository;
            _userId = userId;

            RuleFor(p => p.Name)
                .NotEmpty()
                    .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50)
                    .WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p)
                .MustAsync(PortfolioNameMustBeUnique)
                    .WithMessage("An portfolio with the same name already exists.");
        }

        private async Task<bool> PortfolioNameMustBeUnique(CreatePortfolioCommand command, CancellationToken cancellationToken)
        {
            return !(await _portfolioRepository.PortfolioNameIsDuplicatedForUser(_userId, command.Name));
        }
    }
}
