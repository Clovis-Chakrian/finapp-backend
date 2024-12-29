using Microsoft.AspNetCore.Mvc;

namespace Financa.Backend.BuildingBlocks.Controllers;

[ApiController]
public abstract class AbstractController : ControllerBase
{
  protected static IActionResult CustomResponse<T>(T data)
  {
    return new OkObjectResult(data);
  }

  protected static IActionResult CustomResponse<T>(IEnumerable<T> data)
  {
    if (!data.Any()) return new NoContentResult();
    return new OkObjectResult(data);
  }

  protected static IActionResult BadRequest<T>(T data)
  {
    return new BadRequestObjectResult(data);
  }

  protected static IActionResult NotFound<T>(T data)
  {
    return new NotFoundObjectResult(data);
  }

  protected static IActionResult InternalServerError<T>(T data)
  {
    ObjectResult result = new(data)
    {
      StatusCode = 500
    };

    return result;
  }
}