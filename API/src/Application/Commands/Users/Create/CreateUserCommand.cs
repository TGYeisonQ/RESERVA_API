using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.Create;

public record CreateUserCommand(
    string Id,
    string FirsName,
    string LastName,
    string Email,
    string Password
    ) : IRequest<ErrorOr<Unit>>;

