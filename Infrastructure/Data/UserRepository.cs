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

        public async Task<ICollection<User>> GetUsers()
        {
            return await _context
                .Users
                .Include(user => user.Payments)
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users
                .Where(p => p.Id == id)
                .Include("Payments")
                .FirstOrDefaultAsync();
        }

        public void Create(User user)
        {
            _context.Set<User>().Add(user);
        }

        public void Delete(User user)
        {
            _context.Set<User>().Remove(user);
        }

        public void Update(User user)
        {
            _context.Set<User>().Update(user);
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}