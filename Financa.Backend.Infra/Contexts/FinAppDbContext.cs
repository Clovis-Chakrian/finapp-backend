using Financa.Backend.BuildingBlocks.Data.Repositories;
using Financa.Backend.Domain.Accounts;
using Financa.Backend.Domain.Categories;
using Financa.Backend.Domain.Transactions;
using Microsoft.EntityFrameworkCore;

namespace Financa.Backend.Infra.Contexts;

#nullable disable
public class FinAppDbContext(DbContextOptions<FinAppDbContext> options) : AppDbContext<FinAppDbContext>(options)
{
  public DbSet<Account> Accounts { get; set; }
  public DbSet<Category> Categories { get; set; }
  public DbSet<Transaction> Transactions { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    base.OnConfiguring(optionsBuilder);
    optionsBuilder.EnableDetailedErrors();
    optionsBuilder.EnableSensitiveDataLogging();
    optionsBuilder.UseSnakeCaseNamingConvention();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
      entityType.GetForeignKeys()
        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
        .ToList()
        .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
    }
    base.OnModelCreating(modelBuilder);
  }
}