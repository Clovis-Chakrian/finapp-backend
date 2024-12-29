using AutoMapper;
using Financa.Backend.BuildingBlocks.CQRS.Queries;
using Financa.Backend.BuildingBlocks.Data.Repositories.Read;
using Financa.Backend.Domain.Accounts;

namespace Financa.Backend.Application.Accounts.Queries.GetAll;

public class GetAllAccountsQueryHandler(IReadRepository<Account, Guid> accountReadRepository, IMapper mapper) : IQueryHandler<GetAllAccountsQuery, IEnumerable<ListAccountDto>>
{
  private readonly IReadRepository<Account, Guid> _accountReadRepository = accountReadRepository;
  private readonly IMapper _mapper = mapper;

  public async Task<IEnumerable<ListAccountDto>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
  {
    var accounts = await _accountReadRepository.Search();

    return _mapper.Map<IEnumerable<ListAccountDto>>(accounts);
  }
}