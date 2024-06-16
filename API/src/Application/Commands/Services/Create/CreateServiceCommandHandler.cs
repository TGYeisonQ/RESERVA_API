using Application.Commands.Bookings.Create;
using Domain.Entities.Bookings;
using Domain.Entities.Services;
using Domain.Primitives;
using ErrorOr;
using MediatR;

namespace Application.Commands.Services.Create;

public sealed class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ErrorOr<Unit>>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateServiceCommandHandler(IServiceRepository serviceRepository, IUnitOfWork unitOfWork)
    {
        _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        var booking = new Service
        {
            Id = new Guid(),
            Name = request.Name,
        };
        await _serviceRepository.Add(booking);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
