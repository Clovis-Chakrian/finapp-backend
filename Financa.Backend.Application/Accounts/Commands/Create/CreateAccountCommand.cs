using Financa.Backend.BuildingBlocks.CQRS.Commands;

namespace Financa.Backend.Application.Accounts.Commands.Create;

public class CreateAccountCommand(NewAccountDto newAccountDto) : ICommand<Guid>
{
  public NewAccountDto NewAccountDto { get; set; } = newAccountDto;
}