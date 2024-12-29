using Financa.Backend.BuildingBlocks.Data.Repositories.Read;
using Financa.Backend.Domain.Transactions;
using Financa.Backend.Infra.Contexts;

namespace Financa.Backend.Infra.Repositories.Transactions;

public class TransactionReadRepository(FinAppDbContext context) : ReadRepository<Transaction, Guid, FinAppDbContext>(context)
{
  
}