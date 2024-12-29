using Financa.Backend.BuildingBlocks.Data.Repositories.Write;
using Financa.Backend.Domain.Accounts;
using Financa.Backend.Infra.Contexts;

namespace Financa.Backend.Infra.Repositories.Accounts;

public class AccountWriteRepository(FinAppDbContext context) : WriteRepository<Account, Guid, FinAppDbContext>(context)
{

}