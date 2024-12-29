using Financa.Backend.BuildingBlocks.Data.Repositories.Read;
using Financa.Backend.Domain.Accounts;
using Financa.Backend.Infra.Contexts;

namespace Financa.Backend.Infra.Repositories.Accounts;

public class AccountReadRepository(FinAppDbContext context) : ReadRepository<Account, Guid, FinAppDbContext>(context)
{
  
}