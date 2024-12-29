using Financa.Backend.BuildingBlocks.CQRS.Commands;
using Financa.Backend.BuildingBlocks.CQRS.Queries;
using MediatR;

namespace Financa.Backend.BuildingBlocks.CQRS.Mediator;

public class MediatorHandler(IMediator mediator) : IMediatorHandler
{
  private readonly IMediator _mediator = mediator;

  public async Task<TResult> SendCommand<TCommand, TResult>(TCommand command) where TCommand : ICommand<TResult>
  {
    return await _mediator.Send(command);
  }

  public async Task<TResult> SendQuery<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
  {
    return await _mediator.Send(query);
  }
}