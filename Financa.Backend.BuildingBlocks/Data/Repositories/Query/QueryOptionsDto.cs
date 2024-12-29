namespace Financa.Backend.BuildingBlocks.Data.Repositories.Query;

public class QueryOptionsDto
{
  private string? _order;

  private string? _orderBy;
  public string? UserId { get; set; }

  public string? OrderBy
  {
    get => _orderBy;
    set => _orderBy = value?.ToLowerInvariant();
  }

  public string? Order
  {
    get => _order;
    set => _order = value?.ToLowerInvariant();
  }

  public int Page { get; set; } = 1;

  public int Limit { get; set; } = QueryOptions.DEFAULT_LIMIT;
}