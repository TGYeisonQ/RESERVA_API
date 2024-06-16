using Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories;

public sealed class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public async Task<User?> GetByIdAsync(string mail) => await _context.users.SingleOrDefaultAsync(c => c.Email == mail);
    public async Task<List<User>> GetAll() => await _context.users.ToListAsync();
    public async Task<bool> ExistsAsync(string mail) => await _context.users.AnyAsync(c => c.Email  == mail);
    public async Task Add(User user) => await _context.users.AddAsync(user);
    public void Update(User user) => _context.users.Update(user);
    public void Delete(User user) => _context.users.Remove(user);
}
