using Domain.Entities.Bookings;
using Domain.Primitives;
using ErrorOr;
using MediatR;


namespace Application.Commands.Bookings.Create;
public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, ErrorOr<Unit>>
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateBookingCommandHandler(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    }

    public async Task<ErrorOr<Unit>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = new Booking
        {
            Id = new Guid(),
            Title = request.Title,
            DateBooking = DateTime.Parse(request.DateBooking.ToString()),
            Observations = request.Observations,
            UserId = request.UserId,
            ServiceId = request.ServiceId,
            Created = DateTime.Now,
        };
        await _bookingRepository.Add(booking);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
