using Financa.Backend.BuildingBlocks.Data;

namespace Financa.Backend.Domain.Categories;

public class Category : Entity<Guid>
{
  public string? Name { get; set; }
  public string? Color { get; set; }
  public Guid? PrimaryCategoryId { get; set; }
  public Category? PrimaryCategory { get; set; }
}