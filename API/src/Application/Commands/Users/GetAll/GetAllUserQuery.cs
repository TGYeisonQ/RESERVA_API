using Application.Commands.Users.Common;
using ErrorOr;
using MediatR;


namespace Application.Commands.Users.GetAll;

public record class GetAllUserQuery() : IRequest<ErrorOr<IReadOnlyList<UserResponse>>>;
