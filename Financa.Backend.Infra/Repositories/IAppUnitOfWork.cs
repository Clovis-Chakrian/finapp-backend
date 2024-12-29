using Financa.Backend.BuildingBlocks.Data.Repositories;
using Financa.Backend.BuildingBlocks.Data.Repositories.Write;
using Financa.Backend.Domain.Accounts;
using Financa.Backend.Domain.Categories;
using Financa.Backend.Domain.Transactions;

namespace Financa.Backend.Infra.Repositories;

public interface IAppUnitOfWork : IUnitOfWork
{
  public IWriteRepository<Account, Guid> Accounts { get; }
  public IWriteRepository<Category, Guid> Categories { get; }
  public IWriteRepository<Transaction, Guid> Transactions { get; }
}