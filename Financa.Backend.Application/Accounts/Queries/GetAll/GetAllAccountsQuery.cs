using Financa.Backend.BuildingBlocks.CQRS.Queries;
using Financa.Backend.Domain.Accounts;

namespace Financa.Backend.Application.Accounts.Queries.GetAll;

public class GetAllAccountsQuery : IQuery<IEnumerable<Account>>
{
}