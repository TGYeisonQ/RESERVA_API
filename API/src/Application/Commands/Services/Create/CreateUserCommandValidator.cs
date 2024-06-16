using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Services.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateServiceCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name is required");
    }
}
