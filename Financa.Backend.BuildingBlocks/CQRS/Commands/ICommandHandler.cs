using MediatR;

namespace Financa.Backend.BuildingBlocks.CQRS.Commands;

public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
{
  
}

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
{
  
}