using ErrorOr;
using MediatR;

namespace Application.Commands.Bookings.Create;

public record CreateBookingCommand(
    DateTime DateBooking,
    Guid ServiceId,
    string UserId,
    string Title,
    string Observations
    ) : IRequest<ErrorOr<Unit>>;
