using Application.Commands.Bookings.Common;
using Application.Commands.Services.Common;
using Application.Commands.Users.Common;
using Application.Common.Filtereds;
using Domain.Entities.Bookings;
using ErrorOr;
using MediatR;
using System.Linq.Expressions;


namespace Application.Commands.Bookings.GetFiltered;

public sealed class GetFilteredBookingQueryHandler : IRequestHandler<GetFilteredBookingQuery, ErrorOr<IReadOnlyList<BookingResponse>>>
{
    public readonly IBookingRepository _bookingRepository;

    public GetFilteredBookingQueryHandler(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    public async Task<ErrorOr<IReadOnlyList<BookingResponse>>> Handle(GetFilteredBookingQuery query, CancellationToken cancellationToken)
    {
        var expression = BuildExpression(query);

        IReadOnlyList<Booking> bookings = await _bookingRepository.GetFiltered(expression);


        return bookings.Select(booking => new BookingResponse(
            booking.Id,
            booking.Title,
            booking.Observations ?? "",
            booking.DateBooking,
            new ServiceResponse(
                booking.Service.Id,
                booking.Service.Name
                ),
            new UserResponse(
                booking.User.Id,
                $"{booking.User.FirsName} {booking.User.LastName}"
                )
        )).ToList();
    }

    private static Expression<Func<Booking, bool>> BuildExpression(GetFilteredBookingQuery request)
    {
        var expression = Filteres.New<Booking>();

        if (!string.IsNullOrEmpty(request.filtered.UserId))
            expression = expression.And(b => b.UserId == request.filtered.UserId);

        if (!string.IsNullOrEmpty(request.filtered.DateBooking))
        {
            DateTime convert = DateTime.Parse(request.filtered.DateBooking);

            expression = expression.And(b => DateTime.Compare(b.DateBooking, convert) == 0);
        }
            

        if (request.filtered.ServiceId != null)
            expression = expression.And(b => b.ServiceId == request.filtered.ServiceId);

        return expression;
    }
}
