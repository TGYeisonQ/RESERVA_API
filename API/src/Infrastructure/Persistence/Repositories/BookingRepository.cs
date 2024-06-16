using Domain.Entities.Bookings;
using Domain.Entities.Users;
using Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly ApplicationDbContext _context;

    public BookingRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Booking booking) => await _context.bookings.AddAsync(booking);
    public void Update(Booking booking) => _context.bookings.Update(booking);
    public void Delete(Booking booking) => _context.bookings.Remove(booking);

    public async Task<List<Booking>> GetAll() => await _context.bookings.OrderBy(b => b.Title).ToListAsync();

    public async Task<List<Booking>> GetFiltered(Expression<Func<Booking, bool>> filteres) => await _context.bookings
        .Where(filteres)
        .Select(b => new Booking
            {
                Id = b.Id,
                Title = b.Title,
                DateBooking = b.DateBooking,
                Created = b.Created,
                Observations = b.Observations,
                User = new User
                {
                    Id = b.User.Id,
                    FirsName = b.User.FirsName,
                    LastName = b.User.LastName,
                },
                Service = new Service
                {
                    Id = b.Service.Id,
                    Name = b.Service.Name,
                }

            }
        )
        .OrderBy(b => b.Title)
        .ThenBy(b => b.DateBooking)
        .ToListAsync();

    public async Task<bool> ExistsAsync(Guid id) => await _context.bookings.AnyAsync(company => company.Id == id);
    public async Task<Booking?> GetByIdAsync(Guid id) => await _context.bookings.SingleOrDefaultAsync(c => c.Id == id);
}
