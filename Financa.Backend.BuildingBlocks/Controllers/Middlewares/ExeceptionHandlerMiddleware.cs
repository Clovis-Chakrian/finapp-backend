using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Financa.Backend.BuildingBlocks.Controllers.Responses;
using Financa.Backend.BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Financa.Backend.BuildingBlocks.Controllers.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate next)
{
  private readonly RequestDelegate _next = next;

  public async Task Invoke(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception exception)
    {
      await ErrorHandler(context, exception);
    }
  }

  private static Task ErrorHandler(HttpContext context, Exception exception)
  {
    HttpResponse response = context.Response;
    response.ContentType = "application/json";
    HttpStatusCode httpStatusCode = HandleStatusCode(exception);
    response.StatusCode = (int)httpStatusCode;
    string text = HandlerResponseMessage(httpStatusCode);
    JsonSerializerOptions jsonSerializerOptions = new()
    {
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

    if (exception is not BadRequestException)
    {
      return context.Response.WriteAsync(JsonSerializer.Serialize(
        new ErrorResponse(exception.GetType().Name, text, [], (int)httpStatusCode, httpStatusCode.ToString()),
      jsonSerializerOptions)
      );
    }
    else
    {
      var badRequestException = exception as BadRequestException;

      return context.Response.WriteAsync(JsonSerializer.Serialize(
        new ErrorResponse(exception.GetType().Name, text, badRequestException!.Errors, (int)httpStatusCode, httpStatusCode.ToString()),
      jsonSerializerOptions));
    }
  }

  private static HttpStatusCode HandleStatusCode(Exception ex)
  {
    HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

    if (ex is ValidationException) httpStatusCode = HttpStatusCode.BadRequest;
    if (ex is BadRequestException) httpStatusCode = HttpStatusCode.BadRequest;
    if (ex is RuntimeException) httpStatusCode = HttpStatusCode.InternalServerError;

    return httpStatusCode;
  }

  private static string HandlerResponseMessage(HttpStatusCode httpStatusCode)
  {
    string message = "An error ocurred while processing your request!";

    message = httpStatusCode switch
    {
      HttpStatusCode.BadRequest => "Validation errors ocurred while processing your request!",
      HttpStatusCode.InternalServerError => "An error ocurred while processing your request!",
      HttpStatusCode.NotFound => "The requested resource could not be found!",
      _ => "An error ocurred while processing your request!",
    };
    return message;
  }
}