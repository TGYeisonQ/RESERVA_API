using ErrorOr;
using MediatR;

namespace Application.Commands.Services.Create;

public record CreateServiceCommand (
     string Name
    ) : IRequest<ErrorOr<Unit>>;
