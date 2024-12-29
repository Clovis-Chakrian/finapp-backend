using System.Reflection;

namespace Financa.Backend.BuildingBlocks;

public interface IConfiguration
{
  public List<Assembly> Assemblies { get; set; }
  public List<Type> OpenBehaviors { get; set; }
}