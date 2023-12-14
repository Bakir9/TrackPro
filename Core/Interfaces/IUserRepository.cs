using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<User>> GetUsers();
        Task<User> GetUserById(int id);
        void Add(User user);
        void Delete(User user);
        void Edit(User user);
        Task SaveAsync();
    }
}