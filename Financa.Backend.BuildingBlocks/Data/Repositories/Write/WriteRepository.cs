using Microsoft.EntityFrameworkCore;

namespace Financa.Backend.BuildingBlocks.Data.Repositories.Write;

public abstract class WriteRepository<TEntity, TIdentifier, TDbContext>(TDbContext context) : IWriteRepository<TEntity, TIdentifier> where TEntity : Entity<TIdentifier> where TDbContext : DbContext
{
  private readonly TDbContext _context = context;

  public async Task<TEntity> Create(TEntity entity)
  {
    var createdEntity = await _context.Set<TEntity>().AddAsync(entity);
    return createdEntity.Entity;
  }

  public Task<TEntity> Delete(TEntity entity)
  {
    _context.Set<TEntity>().Remove(entity);
    return Task.FromResult(entity);
  }

  public Task<TEntity> Update(TEntity entity)
  {
    _context.Attach(entity);
    _context.Entry(entity).State = EntityState.Modified;
    return Task.FromResult(entity);
  }
}