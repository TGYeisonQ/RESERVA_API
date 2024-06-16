using Application.Commands.Bookings.Common;
using ErrorOr;
using MediatR;

namespace Application.Commands.Bookings.GetFiltered;

public record class GetFilteredBookingQuery (BookingRequestFiltered filtered) : IRequest<ErrorOr<IReadOnlyList<BookingResponse>>>;
