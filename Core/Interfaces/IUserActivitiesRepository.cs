using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserActivitiesRepository
    {
        public Task<UserActivity> GetActivityByIdWithUsers();
        public Task<UserActivity> AddUsersToActivity();
        public Task<UserActivity> DeleteUsersFromActivity();
    }
}