using Domain.Entities.Bookings;
using Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace Infrastructure.Persistence.Repositories;

public sealed class ServiceRepository : IServiceRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task Add(Service service) => await _context.services.AddAsync(service);

    public void Update(Service service) => _context.services.Update(service);

    public void Delete(Service service) => _context.services.Remove(service);

    public async Task<List<Service>> GetAll() => await _context.services.OrderBy(b => b.Name).ToListAsync();

    public async Task<Service?> GetByIdAsync(Guid id) => await _context.services.SingleOrDefaultAsync(c => c.Id == id);

    public async Task<bool> ExistsAsync(Guid id) => await _context.bookings.AnyAsync(company => company.Id == id);
   
}
