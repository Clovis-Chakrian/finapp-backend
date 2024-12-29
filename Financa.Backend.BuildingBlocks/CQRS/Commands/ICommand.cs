using MediatR;

namespace Financa.Backend.BuildingBlocks.CQRS.Commands;

public interface ICommand<out TResult> : IRequest<TResult>, IBaseCommand
{
  
}

public interface ICommand : IRequest, IBaseCommand
{
  
}

public interface IBaseCommand : IBaseRequest
{}