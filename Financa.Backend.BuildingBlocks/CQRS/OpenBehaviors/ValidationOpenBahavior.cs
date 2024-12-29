using Financa.Backend.BuildingBlocks.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Financa.Backend.BuildingBlocks.CQRS.OpenBehaviors;

public class ValidationOpenBahavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
  private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

  public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
  {
    var context = new ValidationContext<TRequest>(request);

    var validations = await Task.WhenAll(
      _validators.Select(v => v.ValidateAsync(context, cancellationToken))
    );

    var failures = validations
      .SelectMany(result => result.Errors)
      .Where(failure => failure != null)
      .ToList();

    if (failures.Count != 0)
    {
      throw new BadRequestException("Ocurred a validation error", failures.Select((ValidationFailure x) => x.ErrorMessage).ToList());
    }

    return await next();
  }
}