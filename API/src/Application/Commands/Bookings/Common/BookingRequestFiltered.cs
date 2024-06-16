
namespace Application.Commands.Bookings.Common;

public record class BookingRequestFiltered(
        string? DateBooking,
        string? UserId,
        Guid? ServiceId 
    );
