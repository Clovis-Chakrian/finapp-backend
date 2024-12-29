using System.Linq.Expressions;
using Financa.Backend.BuildingBlocks.Data.Repositories.Query;

namespace Financa.Backend.BuildingBlocks.Data.Extensions;

public static class QueryExtensions
{
  public static IQueryable<T> Page<T, TIdentifier>(this IQueryable<T> query, QueryOptions<T, TIdentifier> options) where T : Entity<TIdentifier>
  {
    if (options is not { Page: not null, Limit: not null }) return query;
    var skip = (options.Page.Value - 1) * options.Limit.Value;
    return query.Skip(skip).Take(options.Limit.Value);
  }

  public static IQueryable<T> Order<T, TIdentifier>(this IQueryable<T> query, QueryOrder order,
      Expression<Func<T, object>> orderByExpression) where T : Entity<TIdentifier>
  {
    return order == QueryOrder.Desc ? query.OrderByDescending(orderByExpression) : query.OrderBy(orderByExpression);
  }
}