using Financa.Backend.BuildingBlocks.Controllers;
using Financa.Backend.Infra.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace Financa.Backend.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("/api/healthcheck")]
public class HealthCheckController() : AbstractController
{

  [HttpGet]
  public async Task<IActionResult> Get([FromServices] FinAppDbContext context)
  {
    var app = AppDomain.CurrentDomain.FriendlyName;

    try
    {
      return CustomResponse(await Task.FromResult(new
      {
        Application = app,
        Status = "Started with Success",
        Database = context.Database.CanConnect() ? "OK" : "Fail",
      }));
    }
    catch (Exception ex)
    {
      return InternalServerError(await Task.FromResult(new
      {
        Application = app,
        Status = "Fail to Start",
        Database = "Fail",
        Erro = ex.Message
      }));
    }
  }
}