using Financa.Backend.BuildingBlocks.CQRS.Queries;
using Financa.Backend.BuildingBlocks.Data.Repositories.Read;
using Financa.Backend.Domain.Accounts;

namespace Financa.Backend.Application.Accounts.Queries.GetAll;

public class GetAllAccountsQueryHandler(IReadRepository<Account, Guid> accountReadRepository) : IQueryHandler<GetAllAccountsQuery, IEnumerable<Account>>
{
  private readonly IReadRepository<Account, Guid> _accountReadRepository = accountReadRepository;

  public async Task<IEnumerable<Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
  {
    return await _accountReadRepository.Search();
  }
}