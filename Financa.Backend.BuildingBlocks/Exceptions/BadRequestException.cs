namespace Financa.Backend.BuildingBlocks.Exceptions;

public class BadRequestException(string message, List<string> errors) : Exception(message)
{
  public readonly List<string> _errors = errors;
}