using System.Diagnostics;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IActivityService
    {
       Task<UserActivity> AddMembersToActivity(); 
       Task<IReadOnlyList<UserActivity>> GetActivityMembers();
    }
}