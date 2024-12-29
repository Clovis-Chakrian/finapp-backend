namespace Financa.Backend.BuildingBlocks.Controllers.Responses;

public class ErrorResponse(string exception, string message, List<string> errors, int statusCode, string statusCodeName)
{
  public string Exception { get; set; } = exception;
  public string Message { get; set; } = message;
  public List<string> Errors { get; set; } = errors;
  public int StatusCode { get; set; } = statusCode;
  public string StatusCodeName { get; set; } = statusCodeName;
}