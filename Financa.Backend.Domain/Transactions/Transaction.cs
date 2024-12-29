using Financa.Backend.BuildingBlocks.Data;
using Financa.Backend.Domain.Accounts;
using Financa.Backend.Domain.Categories;

namespace Financa.Backend.Domain.Transactions;

public class Transaction : Entity<Guid>
{
  public TransactionType TransactionType { get; set; }
  public Guid CategoryId { get; set; }
  public Guid AccountId { get; set; }
  public decimal Value { get; set; }
  public string? Remark { get; set; }
  public DateTime Date { get; set; }

  public Account? Account { get; set; }
  public Category? Category { get; set; }
}