using Financa.Backend.Domain.Accounts;

namespace Financa.Backend.Application.Accounts.Commands.Create;

public class NewAccountDto
{
  public string? Nickname { get; set; }
  public AccountType Type { get; set; }
  public decimal Balance { get; set; }
}