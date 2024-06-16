using Domain.Entities.Bookings;


namespace Domain.Entities.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(string mail);
    Task<List<User>> GetAll();
    Task<bool> ExistsAsync(string mail);
    Task Add(User user);
    void Update(User user);
    void Delete(User user);
}
