using System.Reflection;
using Financa.Backend.BuildingBlocks.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Financa.Backend.BuildingBlocks.Data;

public static class DependencyInjection
{
  public static IServiceCollection AddPostgresDb<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : DbContext
  {
    var connectionString = GetConnectionString();

    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    services.AddDbContext<TContext>(options => 
      options.UseNpgsql(connectionString, b => b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
    return services;
  }

  public static IServiceCollection AddRepositories<TUnitOfWork, TUnitOfWorkImpl>(this IServiceCollection services, IEnumerable<Assembly> assemblies) where TUnitOfWork : class, IUnitOfWork where TUnitOfWorkImpl : class, TUnitOfWork
  {
    services.AddScoped<TUnitOfWork, TUnitOfWorkImpl>();
    MapRepositories(services, assemblies);
    return services;
  }

  private static void MapRepositories(IServiceCollection services, IEnumerable<Assembly> assemblies)
  {
    var implementations = assemblies
      .SelectMany(x => x.GetTypes())
      .Where(x => x is { IsClass: true, IsAbstract: false } &&
        x.GetInterfaces().Any(y => y.Name.Contains("Repository") || y.Name.Contains("Repo")));

    foreach (var implementation in implementations)
    {
      foreach (var interfaceType in implementation.GetInterfaces())
      {
        services.AddScoped(interfaceType, implementation);
      }
    }
  }

  private static string GetConnectionString()
  {
    var host = Environment.GetEnvironmentVariable("DB_HOST") ?? throw new Exception("The env variable DB_HOST is required.");
    var username = Environment.GetEnvironmentVariable("DB_USERNAME") ?? throw new Exception("The env variable DB_USERNAME is required.");
    var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? throw new Exception("The env variable DB_PASSWORD is required.");
    var port = Environment.GetEnvironmentVariable("DB_PORT") ?? throw new Exception("The env variable DB_PORT is required.");
    var database = Environment.GetEnvironmentVariable("DB_DATABASE") ?? throw new Exception("The env variable DB_DATABASE is required.");

    return $"Host={host}; Username={username}; Password={password}; Port={port}; Database={database}";
  }
}