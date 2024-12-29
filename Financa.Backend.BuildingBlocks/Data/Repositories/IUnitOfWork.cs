namespace Financa.Backend.BuildingBlocks.Data.Repositories;

public interface IUnitOfWork
{
  public Task Commit();
}