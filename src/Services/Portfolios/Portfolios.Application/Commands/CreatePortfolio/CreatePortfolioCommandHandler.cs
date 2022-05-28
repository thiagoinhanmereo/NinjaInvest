﻿using CleanArch.Application.Contracts.Persistence;
using Portfolios.Application.Contracts;

namespace Portfolios.Application.Commands
{
    public class CreatePortfolioCommandHandler : ICommandHandler<CreatePortfolioCommand, CreatePortfolioCommandResponse>
    {
        private readonly IGenericRepositoryAsync<Portfolio> _portfolioRepository;

        public CreatePortfolioCommandHandler(IGenericRepositoryAsync<Portfolio> portfolioRepository)
        {
            _portfolioRepository = portfolioRepository;
        }

        public async Task<CreatePortfolioCommandResponse> Handle(CreatePortfolioCommand command, CancellationToken cancellation)
        {
            var createPortfolioCommandResponse = new CreatePortfolioCommandResponse();
            var validator = new CreatePortfolioCommandValidator();
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
                //UserId will be hardcoded while auth is not ready
                var userId = "6f2a8888-de3c-4803-af04-aff58f6c3cfe";
                var portfolio = new Portfolio(userId, command.Name);
                portfolio = await _portfolioRepository.AddAsync(portfolio);
                createPortfolioCommandResponse.CreatePortfolioDto = CreatePortfolioDto.Map(portfolio);
            }

            return createPortfolioCommandResponse;
        }
    }
}