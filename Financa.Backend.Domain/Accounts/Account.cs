using Financa.Backend.BuildingBlocks.Data;
using Financa.Backend.Domain.Transactions;

namespace Financa.Backend.Domain.Accounts;

public class Account : Entity<Guid>
{
  public string? Nickname { get; set; }
  public AccountType Type { get; set; }
  public decimal Balance { get; set; }
  public IEnumerable<Transaction>? Transactions { get; set; }
}