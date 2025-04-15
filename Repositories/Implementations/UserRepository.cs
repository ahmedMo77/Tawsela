using Tawsela.Entities;
using Microsoft.EntityFrameworkCore;
using Tawsela.Repositories.Interfaces;
using Tawsela.Data;

namespace Tawsela.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);

        public Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            return Task.CompletedTask;
        }
    }
}