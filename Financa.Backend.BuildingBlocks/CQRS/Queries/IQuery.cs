using MediatR;

namespace Financa.Backend.BuildingBlocks.CQRS.Queries;

public interface IQuery<out TResult> : IRequest<TResult>, IBaseQuery
{
  
}

public interface IQuery : IRequest, IBaseQuery
{
  
}

public interface IBaseQuery : IBaseRequest
{
  
}