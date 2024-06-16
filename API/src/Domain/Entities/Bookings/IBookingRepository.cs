

using System.Linq.Expressions;

namespace Domain.Entities.Bookings;

public interface IBookingRepository
{
    Task<Booking?> GetByIdAsync(Guid id);
    Task<List<Booking>> GetAll();
    Task<List<Booking>> GetFiltered(Expression<Func<Booking, bool>> filteres);
    Task<bool> ExistsAsync(Guid id);
    Task Add(Booking booking);
    void Update(Booking booking);
    void Delete(Booking booking);
}
