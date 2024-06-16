using Application.Commands.Services.Common;
using Application.Commands.Services.GetAll;
using Application.Commands.Users.Common;
using Domain.Entities.Services;
using Domain.Entities.Users;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.GetAll;

public sealed class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, ErrorOr<IReadOnlyList<UserResponse>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<IReadOnlyList<UserResponse>>> Handle(GetAllUserQuery query, CancellationToken cancellationToken)
    {
        IReadOnlyList<User> users = await _userRepository.GetAll();


        return users.Select(user => new UserResponse(
            user.Id,
            $"{user.FirsName} {user.LastName}"
        )).ToList();

    }
}
