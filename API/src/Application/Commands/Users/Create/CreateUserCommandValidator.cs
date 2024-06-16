using FluentValidation;

namespace Application.Commands.Users.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Id).NotNull().NotEmpty().WithMessage("ID is required");
        RuleFor(u => u.FirsName).NotNull().NotEmpty().WithMessage("FirsName is required");
        RuleFor(u => u.LastName).NotNull().NotEmpty().WithMessage("LastName is required");
        RuleFor(u => u.Email).NotNull().NotEmpty().WithMessage("Email is required");
        RuleFor(u => u.Password).NotNull().NotEmpty().WithMessage("Password is required");
    }
}
