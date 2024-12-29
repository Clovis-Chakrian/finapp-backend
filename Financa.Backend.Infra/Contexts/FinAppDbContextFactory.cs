using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Financa.Backend.Infra.Contexts;

public class FinAppDbContextFactory : IDesignTimeDbContextFactory<FinAppDbContext>
{
  public FinAppDbContext CreateDbContext(string[] args)
  {
    var optionsBuilder = new DbContextOptionsBuilder<FinAppDbContext>();
    optionsBuilder.UseNpgsql("XXXX");
    return new FinAppDbContext(optionsBuilder.Options);
  }
}