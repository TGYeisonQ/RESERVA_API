using Application.Common.Security;
using Domain.Entities.Users;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Commands.Users.Create;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<Unit>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var booking = new User
        {
            Id = request.Id,
            FirsName = request.FirsName,
            LastName = request.LastName,
            Email = request.Email,
            Password = HashValue.Hashing(request.Password),
        };
        await _userRepository.Add(booking);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
