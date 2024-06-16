using Domain.Entities.Services;
using Domain.Entities.Users;
using Domain.Primitives;

namespace Domain.Entities.Bookings;

public class Booking : AggregateRoot
{
    public Guid Id { get; set; }

    public DateTime DateBooking { get; set; }

    public Guid ServiceId { get; set; }

    public string UserId { get; set; }

    public string Title { get; set; }

    public string Observations { get; set; }

    public DateTime Created { get; set; }

    public virtual User User { get; set; } = null;

    public virtual Service Service { get; set; } = null;
}
