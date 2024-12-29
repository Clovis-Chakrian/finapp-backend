using Financa.Backend.BuildingBlocks.Data.Repositories;
using Financa.Backend.BuildingBlocks.Data.Repositories.Write;
using Financa.Backend.Domain.Accounts;
using Financa.Backend.Domain.Categories;
using Financa.Backend.Domain.Transactions;
using Financa.Backend.Infra.Contexts;

namespace Financa.Backend.Infra.Repositories;

public class AppUnitOfWork(
  FinAppDbContext context,
  IWriteRepository<Account, Guid> accounts,
  IWriteRepository<Category, Guid> categories,
  IWriteRepository<Transaction, Guid> transactions
) : UnitOfWork<FinAppDbContext>(context), IAppUnitOfWork
{
  public IWriteRepository<Account, Guid> Accounts { get; set; } = accounts;
  public IWriteRepository<Category, Guid> Categories { get; set; } = categories;
  public IWriteRepository<Transaction, Guid> Transactions { get; set; } = transactions;
}