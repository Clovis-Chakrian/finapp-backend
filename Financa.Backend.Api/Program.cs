using System.Reflection;
using Financa.Backend.BuildingBlocks;
using Financa.Backend.BuildingBlocks.CQRS;
using Financa.Backend.BuildingBlocks.Data;
using Financa.Backend.Infra.Contexts;
using Financa.Backend.Infra.Repositories;
using System.IO.Abstractions;
using IConfiguration = Financa.Backend.BuildingBlocks.IConfiguration;
using Financa.Backend.BuildingBlocks.CQRS.OpenBehaviors;
using Financa.Backend.BuildingBlocks.Exceptions;
using Financa.Backend.BuildingBlocks.Controllers.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var currentAssembly = Assembly.GetAssembly(typeof(Program)) ?? throw new RuntimeException("Error while loading program Assemblies.");

Configuration configuration = new()
{
    Assemblies = currentAssembly
        .GetReferencedAssemblies()
        .Where(p => p.FullName.StartsWith("Financa"))
        .Select(Assembly.Load)
        .Union([currentAssembly])
        .ToList(),

    OpenBehaviors = [typeof(ValidationOpenBahavior<,>)]
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

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.Run();