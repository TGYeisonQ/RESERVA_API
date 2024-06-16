using Domain.Entities.Bookings;
using Domain.Primitives;

namespace Domain.Entities.Users;

public class User : AggregateRoot
{
    public string Id { get; set; }
    
    public string FirsName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
