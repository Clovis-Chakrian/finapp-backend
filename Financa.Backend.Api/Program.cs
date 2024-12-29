using System.Reflection;
using Financa.Backend.BuildingBlocks;
using Financa.Backend.BuildingBlocks.CQRS;
using Financa.Backend.BuildingBlocks.Data;
using Financa.Backend.Infra.Contexts;
using Financa.Backend.Infra.Repositories;
using System.IO;
using System.IO.Abstractions;
using IConfiguration = Financa.Backend.BuildingBlocks.IConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var currentAssembly = Assembly.GetAssembly(typeof(Program)) ?? throw new Exception("Error while loading program Assemblies.");

Configuration configuration = new()
{
    Assemblies = currentAssembly
        .GetReferencedAssemblies()
        .Where(p => p.FullName.StartsWith("Financa"))
        .Select(Assembly.Load)
        .Union([currentAssembly])
        .ToList(),

    OpenBehaviors = []
};

builder.Services.AddSingleton<IConfiguration>(configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediator(configuration);
builder.Services.AddPostgresDb<FinAppDbContext>(configuration);
builder.Services.AddRepositories<IAppUnitOfWork, AppUnitOfWork>(configuration.Assemblies);
builder.Services.AddScoped<IFileSystem, FileSystem>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

app.Run();