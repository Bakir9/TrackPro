using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        public readonly StoreContext _context;
        public UserRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<User>> GetUsers()
        {
            return await _context
                .Users.ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users
                .Where(p => p.Id == id)
                .Include(p => p.Payments)
                    .ThenInclude(u => u.Purpose)
                .FirstOrDefaultAsync();
        }

        public void Add(User user)
        {
            _context.Set<User>().Add(user);
        }

        public void Delete(User user)
        {
            _context.Set<User>().Remove(user);
        }

        public void Edit(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}