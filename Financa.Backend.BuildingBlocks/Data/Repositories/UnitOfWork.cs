using Microsoft.EntityFrameworkCore;

namespace Financa.Backend.BuildingBlocks.Data.Repositories;

public abstract class UnitOfWork<TDbContext>(TDbContext context) : IUnitOfWork where TDbContext : DbContext
{
  private readonly TDbContext _context = context;

  public async Task Commit()
  {
    BeforeValidateCommit();
    var changes = await _context.SaveChangesAsync();
    AfterValidateCommit(changes);
  }

  private void BeforeValidateCommit()
  {
    var modifications = _context.ChangeTracker
      .Entries()
      .Where(x => x.State is EntityState.Added or EntityState.Modified or EntityState.Deleted)
      .ToList();

    if (modifications.Count <= 0)
      throw new Exception("You are trying to commit without doing any changes.");
  }

  private static void AfterValidateCommit(int numberOfModifications)
  {
    if (numberOfModifications <= 0)
      throw new Exception("Commit done but it was not possible save changes at database.");
  }
}