using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure
{
    public class ActivityRepository : IActivityRepository
    {
        public readonly StoreContext _context;
        public ActivityRepository(StoreContext context)
        {
            _context = context;
        }

        public void Add(Core.Entities.Activity activity)
        {
             _context.Set<Core.Entities.Activity>().Add(activity);
        }

        public void Delete(Core.Entities.Activity activity)
        {
           _context.Set<Core.Entities.Activity>().Remove(activity);
        }

        public void Edit(Core.Entities.Activity activity)
        {
            _context.Set<Core.Entities.Activity>().Update(activity);
        }

        public async Task<IReadOnlyList<Core.Entities.Activity>> GetActivities()
        {
           return await _context
                .Activities
                .ToListAsync();
        }

        public async Task<Core.Entities.Activity> GetActivityById(int id)
        {
            return await _context.Activities
                .Include(k => k.UserActivities)
                .ThenInclude(u => u.User)
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task SaveAsync()
        {
             await _context.SaveChangesAsync();
        }
    }
}