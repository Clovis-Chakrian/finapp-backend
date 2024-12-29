using System.ComponentModel;

namespace Financa.Backend.BuildingBlocks.Data.Repositories.Query;

public enum QueryOrder
{
  [Description("ASC")] Asc,
  [Description("DESC")] Desc
}