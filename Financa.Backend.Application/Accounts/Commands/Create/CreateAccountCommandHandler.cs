using Financa.Backend.BuildingBlocks.CQRS.Commands;
using Financa.Backend.BuildingBlocks.Data.Repositories.Write;
using Financa.Backend.Domain.Accounts;
using Financa.Backend.Infra.Repositories;

namespace Financa.Backend.Application.Accounts.Commands.Create;

public class CreateAccountCommandHandler(IWriteRepository<Account, Guid> accountWriteRepository, IAppUnitOfWork unitOfWork) : ICommandHandler<CreateAccountCommand, Guid>
{
  private readonly IWriteRepository<Account, Guid> _accountWriteRepository = accountWriteRepository;
  private readonly IAppUnitOfWork _unitOfWork = unitOfWork;

  public async Task<Guid> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
  {
    Account account = new()
    {
      Id = Guid.NewGuid(),
      Nickname = request.NewAccountDto.Nickname,
      Balance = request.NewAccountDto.Balance,
      Type = request.NewAccountDto.Type
    };

    await _accountWriteRepository.Create(account);
    await _unitOfWork.Commit();

    return account.Id;
  }
}