using Application.Commands.Services.Common;
using Application.Commands.Users.Common;


namespace Application.Commands.Bookings.Common;

public record class BookingResponse (
        Guid Id,
        string Title,
        string Observations,
        DateTime DateBooking,
        ServiceResponse Service,
        UserResponse User
    );

