namespace Financa.Backend.BuildingBlocks.Data.Repositories.Write;

public interface IWriteRepository<TEntity, TIdentifier> where TEntity : Entity<TIdentifier>
{
  public Task<TEntity> Create(TEntity entity);
  public Task<TEntity> Update(TEntity entity);
  public Task<TEntity> Delete(TEntity entity);
}