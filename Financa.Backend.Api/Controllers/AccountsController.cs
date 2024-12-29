using Financa.Backend.Application.Accounts.Commands.Create;
using Financa.Backend.Application.Accounts.Queries.GetAll;
using Financa.Backend.BuildingBlocks.Controllers;
using Financa.Backend.BuildingBlocks.CQRS.Mediator;
using Financa.Backend.Domain.Accounts;
using Financa.Backend.Infra.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Financa.Backend.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("/api/accounts")]
public class AccountsController(IMediatorHandler mediator) : AbstractController
{
  private readonly IMediatorHandler _mediator = mediator;

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] NewAccountDto newAccountDto)
  {
    return CustomResponse(await _mediator.SendCommand<CreateAccountCommand, Guid>(new CreateAccountCommand(newAccountDto)));
  }

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    return CustomResponse(await _mediator.SendQuery<GetAllAccountsQuery, IEnumerable<ListAccountDto>>(new GetAllAccountsQuery()));
  }
}