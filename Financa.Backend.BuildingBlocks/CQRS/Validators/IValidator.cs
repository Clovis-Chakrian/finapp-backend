using Financa.Backend.BuildingBlocks.CQRS.Commands;
using Financa.Backend.BuildingBlocks.CQRS.Queries;
using FluentValidation;

namespace Financa.Backend.BuildingBlocks.CQRS.Validators;

public abstract class AppValidator<TBaseQueryCommand> : AbstractValidator<TBaseQueryCommand>
{
  
}