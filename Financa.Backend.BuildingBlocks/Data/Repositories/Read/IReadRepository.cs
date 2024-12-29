using System.Linq.Expressions;
using Financa.Backend.BuildingBlocks.Data.Repositories.Query;

namespace Financa.Backend.BuildingBlocks.Data.Repositories.Read;

public interface IReadRepository<TEntity, TIdentifier> where TEntity : Entity<TIdentifier>
{
  public Task<IEnumerable<TEntity>> Search();
  public Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> expression, QueryOptions<TEntity, TIdentifier>? options = null, IEnumerable<string>? includes = null);
  public Task<int> Count();
  public Task<int> Count(Expression<Func<TEntity, bool>> expression);
  public Task<TEntity?> Find(TIdentifier id);
  public Task<TEntity?> Find(Expression<Func<TEntity, bool>> expression, IEnumerable<string>? includes = null);
  public Task<bool> Exists();
  public Task<bool> Exists(Expression<Func<TEntity, bool>> expression);
}