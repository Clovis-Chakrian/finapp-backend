using Financa.Backend.BuildingBlocks.CQRS.Commands;
using Financa.Backend.BuildingBlocks.CQRS.Queries;

namespace Financa.Backend.BuildingBlocks.CQRS.Mediator;

public interface IMediatorHandler
{
  public Task<TResult> SendCommand<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>;
  public Task<TResult> SendQuery<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
}