using System.Linq.Expressions;

namespace Financa.Backend.BuildingBlocks.Data.Repositories.Query;

public static class QueryOptions
{
  public const int MAX_LIMIT = 100;
  public const int MIN_LIMIT = 1;
  public const int DEFAULT_LIMIT = 25;
  public const int MIN_PAGE = 1;
}

public class QueryOptions<TSource, TIdentifier> where TSource : Entity<TIdentifier>
{
  public Expression<Func<TSource, object>>? OrderBy { get; set; }
  public QueryOrder? Order { get; set; }
  public int? Page { get; set; }
  public int? Limit { get; set; }
}