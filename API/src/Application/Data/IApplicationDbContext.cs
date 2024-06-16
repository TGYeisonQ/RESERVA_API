using Domain.Entities.Bookings;
using Domain.Entities.Services;
using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
    DbSet<Booking> bookings  { get; set; }
    DbSet<Service> services { get; set; }
    DbSet<User> users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
