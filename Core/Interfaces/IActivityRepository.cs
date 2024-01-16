using Core.Entities;

namespace Core.Interfaces
{
    public interface IActivityRepository
    {
        Task<IReadOnlyList<Activity>> GetActivities();
        Task<Activity> GetActivityById(int id);
        void Add(Activity activity);
        void Delete(Activity activity);
        void Edit(Activity activity);
        Task SaveAsync();
    }
}