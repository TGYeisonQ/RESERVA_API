using Domain.Entities.Bookings;
using Domain.Primitives;

namespace Domain.Entities.Services;

public class Service : AggregateRoot
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
