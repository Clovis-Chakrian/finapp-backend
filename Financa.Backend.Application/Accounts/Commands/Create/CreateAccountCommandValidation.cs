using FluentValidation;

namespace Financa.Backend.Application.Accounts.Commands.Create;

public class CreateAccountCommandValidation : AbstractValidator<CreateAccountCommand>
{
  public CreateAccountCommandValidation()
  {
    RuleFor(p => p.NewAccountDto.Nickname)
      .NotEmpty()
      .WithMessage("Nickname is required");
  }
}