using Financa.Backend.BuildingBlocks.CQRS.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace Financa.Backend.BuildingBlocks.CQRS;

public static class DependencyInjection
{
  public static void AddMediator(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddMediatR(cfg =>
    {
      cfg.RegisterServicesFromAssemblies([.. configuration.Assemblies]);
      foreach (var openBehavior in configuration.OpenBehaviors)
      {
        cfg.AddOpenBehavior(openBehavior);
      }
    });

    services.AddScoped<IMediatorHandler, MediatorHandler>();
  }
}