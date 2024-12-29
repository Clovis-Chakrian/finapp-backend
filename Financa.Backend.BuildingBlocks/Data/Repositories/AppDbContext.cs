using Microsoft.EntityFrameworkCore;

namespace Financa.Backend.BuildingBlocks.Data.Repositories;

public abstract class AppDbContext<TDbContext>(DbContextOptions<TDbContext> options) : DbContext(options) where TDbContext : DbContext
{
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(TDbContext).Assembly);
  }

  public override int SaveChanges()
  {
    OnBeforeSaveChanges();
    return base.SaveChanges();
  }

  public override int SaveChanges(bool acceptAllChangesOnSuccess)
  {
    OnBeforeSaveChanges();
    return base.SaveChanges(acceptAllChangesOnSuccess);
  }

  public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
  {
    OnBeforeSaveChanges();
    return base.SaveChangesAsync(cancellationToken);
  }

  public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
      CancellationToken cancellationToken = default)
  {
    OnBeforeSaveChanges();
    return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
  }

  public void OnBeforeSaveChanges()
  {
    foreach (var entry in ChangeTracker.Entries().Where(entry =>
      entry.Properties.FirstOrDefault(p => p.Metadata.Name == "CreatedAt") != null))
    {
      if (entry.State == EntityState.Added)
        entry.Properties.FirstOrDefault(p => p.Metadata.Name == "CreatedAt")!.CurrentValue = DateTime.Now;
    }

    foreach (var entry in ChangeTracker.Entries().Where(entry =>
      entry.Properties.FirstOrDefault(p => p.Metadata.Name == "UpdatedAt") != null))
    {
      if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
        entry.Properties.FirstOrDefault(p => p.Metadata.Name == "UpdatedAt")!.CurrentValue = DateTime.Now;
    }
  }
}