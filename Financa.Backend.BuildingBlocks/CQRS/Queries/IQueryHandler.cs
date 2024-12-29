using MediatR;

namespace Financa.Backend.BuildingBlocks.CQRS.Queries;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
  
}