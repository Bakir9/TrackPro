using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserActivitiesRepository
    {
        public Task<UserActivities> GetActivityByIdWithUsers();
        public Task<UserActivities> AddUsersToActivity();
        public Task<UserActivities> DeleteUsersFromActivity();
    }
}