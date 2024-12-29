using System.Linq.Expressions;
using Financa.Backend.BuildingBlocks.Data.Extensions;
using Financa.Backend.BuildingBlocks.Data.Repositories.Query;
using Microsoft.EntityFrameworkCore;

namespace Financa.Backend.BuildingBlocks.Data.Repositories.Read;

public abstract class ReadRepository<TEntity, TIdentifier, TDbContext>(TDbContext context) : IReadRepository<TEntity, TIdentifier> where TEntity : Entity<TIdentifier> where TDbContext : DbContext
{
  private readonly TDbContext _context = context;

  public async Task<bool> Exists()
  {
    return await _context.Set<TEntity>().AnyAsync();
  }

  public async Task<bool> Exists(Expression<Func<TEntity, bool>> expression)
  {
    return await _context.Set<TEntity>().AnyAsync(expression);
  }

  public async Task<int> Count()
  {
    return await _context.Set<TEntity>()
      .AsNoTracking()
      .CountAsync();
  }

  public async Task<int> Count(Expression<Func<TEntity, bool>> expression)
  {
    return await _context.Set<TEntity>()
      .AsNoTracking()
      .CountAsync(expression);
  }

  public async Task<TEntity?> Find(TIdentifier id)
  {
    return await _context.Set<TEntity>()
      .FindAsync(id);
  }

  public async Task<TEntity?> Find(Expression<Func<TEntity, bool>> expression, IEnumerable<string>? includes = null)
  {
    IQueryable<TEntity> query = _context.Set<TEntity>().AsQueryable();

    if (includes == null)
    {
      return await query
        .AsNoTracking()
        .AsSplitQuery()
        .FirstOrDefaultAsync();
    }

    query = includes.Aggregate(query, (current, include) => current.Include(include));

    return await query
        .AsNoTracking()
        .AsSplitQuery()
        .FirstOrDefaultAsync(expression);
  }

  public async Task<IEnumerable<TEntity>> Search()
  {
    return await _context.Set<TEntity>()
      .AsNoTracking()
      .ToListAsync();
  }

  public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> expression, QueryOptions<TEntity, TIdentifier>? options = null, IEnumerable<string>? includes = null)
  {

    IQueryable<TEntity> query = _context.Set<TEntity>().AsQueryable();

    if (options != null)
    {
      if (options.OrderBy != null)
      {
        query = query.Order<TEntity, TIdentifier>(options.Order ?? QueryOrder.Asc, options.OrderBy);
      }

      if (options.Page != null && options.Limit != null)
      {
        query = query.Page<TEntity, TIdentifier>(options);
      }
    }

    if (includes == null)
    {
      return await query
        .AsNoTracking()
        .AsSplitQuery()
        .ToListAsync();
    }

    query = includes.Aggregate(query, (current, include) => current.Include(include));

    return await query
        .AsNoTracking()
        .AsSplitQuery()
        .ToListAsync();
  }
}