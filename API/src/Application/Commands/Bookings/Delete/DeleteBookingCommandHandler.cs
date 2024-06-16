using Domain.Entities.Bookings;
using Domain.Primitives;
using ErrorOr;
using MediatR;


namespace Application.Commands.Bookings.Delete;

public sealed class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand, ErrorOr<Unit>>
{
    public readonly IBookingRepository _bookingRepository;
    public readonly IUnitOfWork _unitOfWork;

    public DeleteBookingCommandHandler(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteBookingCommand command, CancellationToken cancellationToken)
    {
        if (await _bookingRepository.GetByIdAsync(command.Id) is not Booking booking)
            return Error.NotFound("Bookin.NotFound", "The booking with the provide Id was not found.");

        _bookingRepository.Delete(booking);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
