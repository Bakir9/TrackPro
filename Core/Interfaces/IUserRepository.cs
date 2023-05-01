using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task<ICollection<User>> GetUsers();
        Task<User> GetUserById(int id);
        void Create(User user);
        void Delete(User user);
        void Update(User user);
        Task SaveAsync();
        Task<IReadOnlyList<User>> GetUserPayment();
    }
}