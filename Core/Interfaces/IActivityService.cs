using System.Diagnostics;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IActivityService
    {
       Task<UserActivities> AddMembersToActivity(); 
       Task<IReadOnlyList<UserActivities>> GetActivityMembers();
    }
}