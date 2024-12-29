using Financa.Backend.BuildingBlocks.CQRS.Mediator;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Financa.Backend.BuildingBlocks.CQRS;

public static class DependencyInjection
{
  public static void AddMediator(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddAutoMapper(configuration.Assemblies);

    services.AddMediatR(cfg =>
    {
      cfg.RegisterServicesFromAssemblies([.. configuration.Assemblies]);
      foreach (var openBehavior in configuration.OpenBehaviors.AsParallel())
      {
        cfg.AddOpenBehavior(openBehavior);
      }
    });

    services.AddValidatorsFromAssemblies(configuration.Assemblies);

    services.AddScoped<IMediatorHandler, MediatorHandler>();
  }
}