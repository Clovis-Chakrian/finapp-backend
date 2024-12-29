namespace Financa.Backend.BuildingBlocks.Data;

public class Entity<T>
{
  public required T Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public T? CreatedBy { get; set; }
  public T? UpdatedBy { get; set; }
}