using ErrorOr;
using MediatR;


namespace Application.Commands.Bookings.Delete;

public record DeleteBookingCommand (Guid Id) : IRequest<ErrorOr<Unit>>;
