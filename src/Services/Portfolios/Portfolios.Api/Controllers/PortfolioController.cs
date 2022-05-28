using Microsoft.AspNetCore.Mvc;
using Portfolios.Application.Commands;
using Portfolios.Application.Contracts;

namespace Portfolios.Controllers;

[ApiController]
[Route("[controller]")]
public class PortfolioController : ControllerBase
{
    public static List<Portfolio> Portfolios { get; set; } = new List<Portfolio>();

    protected readonly ICommandDispatcher _commandDispatcher;

    public PortfolioController(ICommandDispatcher commandDispatcher) //TODO - Add tests
    {
        _commandDispatcher = commandDispatcher ?? throw new ArgumentNullException();
    }

    [HttpGet()]
    [ProducesResponseType(typeof(IEnumerable<CreatePortfolioDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        return Ok(Portfolios.Select(p => PortfolioDto.Map(p)));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PortfolioDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(string id)
    {
        var portfolio = Portfolios.Find(p => p.Id == id);

        if (portfolio is null)
            return NotFound();

        return Ok(PortfolioDto.Map(portfolio));            
    }

    [HttpPost()]
    [ProducesResponseType(typeof(CreatePortfolioCommandResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(CreatePortfolioCommandResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(string name)
    {
        var response = await _commandDispatcher.Dispatch(new CreatePortfolioCommand(name));

        //TO DO - Create middleware
        if (response.ValidationErrors.Any())
        {
            return BadRequest(response.ValidationErrors);
        }

        return CreatedAtAction(nameof(GetById), new { id = response.CreatePortfolioDto.Id }, response);
    }
}
