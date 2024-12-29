using Financa.Backend.BuildingBlocks.Data.Repositories.Write;
using Financa.Backend.Domain.Transactions;
using Financa.Backend.Infra.Contexts;

namespace Financa.Backend.Infra.Repositories.Transactions;

public class TransactionWriteRepository(FinAppDbContext context) : WriteRepository<Transaction, Guid, FinAppDbContext>(context)
{

}